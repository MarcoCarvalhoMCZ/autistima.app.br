# AUTistima - Instruções para Agentes de IA

## Visão Geral
Rede de apoio digital para **mães atípicas** (mães de pessoas autistas). **Stack**: ASP.NET Core 9.0 MVC + SQL Server + EF Core 9.0 (schema: `autistima_sa_sql`).  
**Idioma obrigatório**: pt-BR em TODO código (variáveis, labels, comentários, mensagens).

## Startup & Ambiente

### Comandos Essenciais
```bash
./testar.sh [porta]                      # Executa na porta (padrão 5000), libera port se necessário
cd AUTistima && dotnet ef migrations add NomeMigração  # Nova migration
dotnet run                               # Executa direto de AUTistima/
```

**CRÍTICO**: 
- Migrations **aplicadas automaticamente** ao iniciar (`Program.cs` linhas 90+) — NUNCA rodar `dotnet ef database update` manualmente em dev
- Admin padrão: `lorena@autistima.app.br` / `Lorena@2025` → **altere em produção**
- Cookies: `ExpireTimeSpan = 30 dias`, `SlidingExpiration = true`

## Arquitetura de Autorização

### TipoPerfil (NÃO usa ASP.NET Roles)
Sistema de autorização customizado via **enum `TipoPerfil`**. Cada área deve implementar verificação manual:

```csharp
// Areas/Admin/Controllers/XxxController.cs - obrigatório em TODA action de área
private async Task<bool> IsAdmin() {
    var user = await _userManager.GetUserAsync(User);
    return user?.TipoPerfil == TipoPerfil.Administrador;
}

[HttpGet]
public async Task<IActionResult> Index() {
    if (!await IsAdmin()) return RedirectToAction("Index", "Home", new { area = "" });
    // ... lógica
}
```

| Área | Enum | Valores | Controller Padrão |
|------|------|---------|-------------------|
| `/Admin/*` | `Administrador` | 0 | `Areas/Admin/Controllers/AdminController.cs` |
| `/Mae/*` | `Mae` | 1 | `Areas/Mae/Controllers/...` |
| `/Profissional/*` | `ProfissionalSaude` (2), `ProfissionalEducacao` (3) | 2-3 | `Areas/Profissional/Controllers/ProfissionalController.cs` |
| `/Empresa/*` | `Empresa` | 4 | `Areas/Empresa/Controllers/...` |
| `/Governo/*` | `Governo` | 5 | `Areas/Governo/Controllers/...` |

## Padrões de Controller

### Injeção Obrigatória
```csharp
public class XxxController : Controller {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<XxxController> _logger;
    private readonly IActivityTrackingService _activityService;  // opcional para ações críticas

    public XxxController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<XxxController> logger) {
        _context = context;
        _userManager = userManager;
        _logger = logger;
    }
}
```

### Padrão CRUD Create (Exemplo Real)
```csharp
[HttpPost, ValidateAntiForgeryToken, Authorize]
public async Task<IActionResult> Create([Bind("Titulo,Descricao")] Post item) {
    ModelState.Remove("UserId");      // SEMPRE remover campos server-side
    ModelState.Remove("Autor");       // Remover navegações também
    
    item.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    item.DataCriacao = DateTime.UtcNow;
    item.Ativo = true;
    
    if (ModelState.IsValid) {
        _context.Add(item);
        await _context.SaveChangesAsync();
        
        // Log da atividade (APENAS para ações críticas)
        // await _activityService.RegistrarAtividade(item.UserId, TipoAtividade.CriacaoPost);
        
        TempData["Mensagem"] = "Seu post foi compartilhado com carinho! 💕";
        return RedirectToAction(nameof(Index));
    }
    return View(item);
}
```

**Feedback**: SEMPRE usar emoji em `TempData["Mensagem"]` (sucesso) e `TempData["Erro"]` (erro).

## Padrões de Model

### Template Base (Soft Delete Obrigatório)
```csharp
public class ExemploModel {
    [Key] public int Id { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(200)]
    [Display(Name = "Seu Label em Português")]
    public string Campo { get; set; } = string.Empty;
    
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public bool Ativo { get; set; } = true;  // Soft delete — NUNCA deletar fisicamente
    
    // FK para autor (obrigatória)
    [Required] public string UserId { get; set; } = string.Empty;
    [ForeignKey("UserId")] public virtual ApplicationUser? Autor { get; set; }
}
```

### Relacionamentos em `OnModelCreating` (DbContext)
```csharp
builder.Entity<Post>(entity => {
    entity.ToTable("Posts");
    entity.HasIndex(e => e.UserId);
    
    entity.HasOne(e => e.Autor)
        .WithMany(u => u.Posts)
        .HasForeignKey(e => e.UserId)
        .OnDelete(DeleteBehavior.Restrict);  // Impede deletar usuário com posts
});
```

**Estratégias de Delete**:
- `Restrict`: FK obrigatória — não permite excluir pai se tem filhos
- `SetNull`: FK opcional — define null ao excluir pai
- `Cascade`: Exclui filhos junto (usar com cuidado)

## Domínio Crítico

| Termo | Significado | Referência |
|-------|-------------|-----------|
| **Manejos** | "Saberes não cientificizados" — estratégias práticas das mães (NÃO são prescrições). Validáveis por profissionais. | `Models/Manejo.cs`, enum `CategoriaManejo` |
| **Acolhimento** | Reação empática (like) em posts. Toggle via `PostAcolhimento` com índice único `(PostId, UserId)`. | `Controllers/AcolhimentoController.cs` |
| **Central** | Feed social onde posts são "acolhidos" (não "curtidos"). | `Controllers/AcolhimentoController.cs` |
| **Triagem** | Solicitação de avaliação: Professor → aguarda Profissional Saúde → Parecer + Recomendações. | `Models/ScreeningRequest.cs`, `StatusTriagem` enum |
| **Chat** | Mensagens diretas entre usuários (`ChatMessage`, `Conversation`). | `Controllers/ChatController.cs` |

### Fluxo de Triagem
```
Professor (ProfissionalEducacao) cria ScreeningRequest
  → Status = Pendente
  ↓
Profissional Saúde acessa e avalia
  → Status = EmAvaliacao, adiciona ParecerProfissional
  ↓
Conclusão
  → Status = Concluida, adiciona Recomendacoes + Encaminhamento
  ↓
Cancelada (se necessário)
  → Status = Cancelada
```
**Ver**: `Areas/Profissional/Controllers/ProfissionalController.cs`

## Serviços (DI em Program.cs)

| Serviço | Interface | Responsabilidade | Registro |
|---------|-----------|------------------|----------|
| AIService | `IAIService` | Sugestões de manejos, termos glossário, profissionais (via IA ou fallback) | `AddAIServices()` |
| PushNotification | `IPushNotificationService` | Push WebPush para PWA (chaves VAPID em appsettings) | `AddScoped<IPushNotificationService, PushNotificationService>()` |
| ActivityTracking | `IActivityTrackingService` | Registra ações críticas (login, posts, acolhimentos) com IP/UserAgent | `AddScoped<IActivityTrackingService, ActivityTrackingService>()` |
| Statistics | `IStatisticsService` | Dashboard: métricas, engajamento, snapshots diários | `AddScoped<IStatisticsService, StatisticsService>()` |

### Exemplo: Notificações com Push
```csharp
// Em qualquer controller
await NotificacoesController.CriarNotificacao(
    _context, 
    userId, 
    "💕 Título empático", 
    "Mensagem de suporte",
    TipoNotificacao.Acolhimento,  // enum
    "/Link/Para/Acao",
    _pushService  // IPushNotificationService injetado
);
```

### Exemplo: Rastreamento de Atividades
```csharp
// Registro simples
await _activityService.RegistrarAtividade(userId, TipoAtividade.Login);

// Com contexto HTTP (IP, UserAgent)
await _activityService.RegistrarAtividadeComContexto(userId, TipoAtividade.Login, HttpContext);
```

### Exemplo: Métricas & Dashboard
```csharp
// Em Admin Dashboard
var metricas = await _statisticsService.ObterMetricasDashboard();
var engajamento = await _statisticsService.ObterMetricasEngajamento();
// engajamento.TaxaEngajamento = usuários ativos / total
```

## UI/UX - Tom & Paleta

### Tom
Sempre **acolhedor, empático, com emojis**:
```csharp
TempData["Mensagem"] = "Sua mensagem foi compartilhada com carinho. Você não está sozinha! 💕";
TempData["Erro"] = "Ops! Algo deu errado. Tente novamente. 🤗";
```

### Cores (em `wwwroot/css/site.css`)
- **Primária (Salmon)**: `#F28B82` → classes `btn-salmon`, `text-salmon`, `bg-salmon-light`
- **Secundária (Azul bebê)**: `#AECBFA`
- **Destaque (Amarelo)**: `#FCE883`
- **Contraste**: fundo branco, texto preto

### Ícones
Bootstrap Icons (`bi bi-*`): `bi-heart-fill`, `bi-chat-heart`, `bi-people-fill`, `bi-star-fill`

## PWA - Progressive Web App

Sistema é PWA completo com offline support:
- **Manifest**: `wwwroot/manifest.json` — cores tema, ícones em `wwwroot/icons/`
- **Service Worker**: `wwwroot/service-worker.js` — cache com `CACHE_VERSION = 'v1.0.0'` (incrementar a cada deploy)
- **Offline**: `wwwroot/offline.html` — página exibida sem conexão
- **Push**: Chaves VAPID em `Services/PushNotificationService.cs`

## Workflow: Adicionar Entidade Nova

1. **Criar Model** em `Models/` com soft delete (`Ativo`, `DataCriacao`, `UserId`)
2. **Adicionar DbSet** em `Data/ApplicationDbContext.cs`
3. **Configurar relacionamentos** em `OnModelCreating()` (índices, FKs, DeleteBehavior)
4. **Criar Migration**: `cd AUTistima && dotnet ef migrations add NomeEntidade`
5. **Seed (opcional)**: Método `SeedXxx()` em `ApplicationDbContext.cs` (executado automaticamente)

Exemplos existentes: `SeedGlossaryTerms()`, `SeedServicesCapsMaceio()`, `SeedManejosIniciais()`

## Arquivos de Referência Rápida

| Para entender... | Arquivo |
|------------------|---------|
| DI, Identity, startup, auto-migrations | `Program.cs` |
| Schema completo, entidades, relacionamentos | `Data/ApplicationDbContext.cs` |
| Extensão do Identity | `Models/ApplicationUser.cs` |
| Enums (TipoPerfil, CategoriaManejo, etc.) | `Models/Enums/*.cs` |
| CRUD padrão (público) | `Controllers/AcolhimentoController.cs` |
| CRUD com verificação admin | `Areas/Admin/Controllers/AdminController.cs` |
| Serviços (IA, Push, Stats, Activity) | `Services/` |
| Variáveis CSS, cores, responsive | `wwwroot/css/site.css` |
| Routing de áreas | `Program.cs` linhas 78-88 |

## Checklist para PR (Pull Request)

- [ ] Código em **pt-BR** (variáveis, comentários, labels)
- [ ] `ModelState.Remove()` usado para campos server-side em formulários
- [ ] Soft delete: `Ativo = true` em Insert, sem DELETE físico
- [ ] FK para `ApplicationUser` com `[ForeignKey]` atributo
- [ ] `TempData["Mensagem"]` com emoji para feedback ao usuário
- [ ] `OnDelete(DeleteBehavior.Restrict)` para FKs críticas (usuário, perfil)
- [ ] Verificação `IsAdmin()` ou equivalente em controllers de área
- [ ] Atividades críticas registradas via `_activityService`
- [ ] Sem hardcoding de URLs — usar `Url.Action()`, `nameof()`
- [ ] Migrations criadas e testadas localmente

---

**Versão do documento**: v1.1 (8 dez 2025)  
**Stack validado**: ASP.NET Core 9.0, EF Core 9.0, .NET 9.0
