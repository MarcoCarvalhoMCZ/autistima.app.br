# AUTistima - Instruções para Agentes de IA

## Visão Geral
**Stack:** ASP.NET Core 9 MVC + EF Core 9 + SQL Server  
**Idioma:** Português (pt-BR) obrigatório em código, comentários, UI e commits.

Plataforma monolítica MVC com **Areas por perfil** (`Admin`, `Empresa`, `Governo`, `Mae`, `Profissional`). Foco acessibilidade (PWA, mobile-first, sem JS obrigatório). 

## Arquitetura Crítica

### Modelos Centrais
- **`ApplicationUser`** ([ApplicationUser.cs](AUTistima/Models/ApplicationUser.cs)): Base do Identity com `TipoPerfil` (não roles), campos de pessoa (CPF), empresa (CNPJ, RegistroProfissional), endereço, e consentimentos. Campo `Ativo` sempre para soft-delete.
- **Enums principais** ([Enums/](AUTistima/Models/Enums)): `TipoPerfil`, `CategoriaManejo`, `StatusAprovacao`, `TipoAtividade`, `Especialidade`, `StatusTriagem`.
- **Entidades-chave**: `Child`, `Post`, `Manejo`, `ChatMessage`, `PanicAlert`, `Service`, `School`.

### Banco de Dados (EF Core)
- **Schema único:** `autistima_sa_sql` ([ApplicationDbContext.cs](AUTistima/Data/ApplicationDbContext.cs), linha 40).
- **Soft-delete:** Sempre adicione propriedade `Ativo` (bool, default true) — nunca `DELETE` físico.
- **Relacionamentos:** Use `DeleteBehavior.Restrict` para usuários/histórico, `SetNull` para referências opcionais. **Nunca `Cascade`**.
- **Queries:** Sempre use `.Include()` para evitar N+1; exemplo em [AcolhimentoController.cs](AUTistima/Controllers/AcolhimentoController.cs) linhas 41-44.

### Serviços de Negócio
- **`AIService`** ([AIService.cs](AUTistima/Services/AIService.cs)): Interface `IAIService` com métodos `SugerirManejosPorCategoria()`, `SugerirTermosRelacionados()`. Registrado via `AddAIServices()` extension ([linha 52](AUTistima/Program.cs#L52)).
- **`SentimentService`**: Singleton para análise de texto.
- **`PanicService`** ([PanicService.cs](AUTistima/Services/PanicService.cs)): Alertas de pânico com `.Include(p => p.Usuario)` para dados completos.
- **`ActivityTrackingService`**: Registra ações críticas via `RegistrarAtividadeComContexto(userId, tipo, httpContext, detalhes)` — exemplo em [AccountController.cs](AUTistima/Controllers/AccountController.cs) linha 65.
- **`PushNotificationService`**: WebPush com VAPID para notificações.

### Autenticação & Autorização
- **Validação:** Sempre verificar `TipoPerfil` no backend (não confiar em UI). Métodos auxiliares em Controllers: `IsMae()`, `IsProfissional()`.
- **Sessão:** Identity + cookies (expires 30 dias, sliding expiration).
- **Redirects:** Redirecionar a `/Account/Login` se não autenticado.

## Workflow Prático

**Executar:** `./testar.sh [porta]` (padrão 5000). Script mata processos zumbis, não use `dotnet run` diretamente.

**Migrations:** Na pasta `AUTistima/`:
```bash
dotnet ef migrations add NomeMigration
# Não aplicar manualmente — Program.cs autoaplica no startup
```

**Areas:** Cada area (`/Areas/{Area}/Controllers/`) é isolada. Use `Area.{Area}` em redirects.

## Padrões Específicos

### Frontend (Bootstrap 5)
- Cores: Primária `#F28B82` (salmão), Secundária `#AECBFA` (azul).
- Feedback: `TempData["Mensagem"]` com emojis ("✅ Salvo", "❌ Erro").
- Acessibilidade: Sem JS obrigatório; PWA com Service Worker.

### Queries & Performance
- **Eager loading obrigatório:** `.Include(x => x.Relacao).ThenInclude(...)` para evitar lazy-load em views.
- **No N+1:** Revisar queries complexas; manejos carregam autores em [BuscaController.cs](AUTistima/Controllers/BuscaController.cs) linha 62.
- **SaveChanges:** Await sempre; ex: `await _context.SaveChangesAsync()` ([AcolhimentoController.cs](AUTistima/Controllers/AcolhimentoController.cs) linha 76).

### Testes Críticos
Teste manualmente: Login, Cadastro com validação de CPF/CNPJ, Chat real-time (SignalR), Alertas de Pânico.

## Integração SignalR
Hub em [ChatHub.cs](AUTistima/Hubs/ChatHub.cs); métodos async para mensagens real-time. Configure em `Program.cs` com `builder.Services.AddSignalR()`.

## Admin & Seeding
- **Usuário padrão:** `lorena@autistima.app.br` (seed em migrations).
- **Glossário:** Mini-dicionário seeded em [20251205220847_SeedMiniDicionarioTermos.cs](AUTistima/Migrations/20251205220847_SeedMiniDicionarioTermos.cs).
- **Escolas:** Seed de Maceió em [20251205205316_SeedCapsMaceio.cs](AUTistima/Migrations/20251205205316_SeedCapsMaceio.cs).
