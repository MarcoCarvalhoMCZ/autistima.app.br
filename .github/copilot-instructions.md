# AUTistima - Instruções para Agentes de IA

## Visão Geral do Projeto

**AUTistima** é uma rede de apoio digital para mães atípicas (mães de pessoas autistas), conectando-as com profissionais de saúde/educação e empresas. A plataforma prioriza **acolhimento, acessibilidade e conhecimento de vivência**.

## Stack Tecnológica

- **Framework**: ASP.NET Core 9.0 (MVC com Razor Views)
- **Banco de Dados**: SQL Server com Entity Framework Core 9.0
- **Autenticação**: ASP.NET Core Identity com `ApplicationUser` customizado
- **Schema do Banco**: `autistima_sa_sql`
- **Idioma**: Português brasileiro (pt-BR) - todas as mensagens, labels e documentação devem seguir este padrão

## Arquitetura e Estrutura

### Organização por Áreas
```
AUTistima/
├── Areas/
│   ├── Admin/         # Painel administrativo (TipoPerfil.Administrador)
│   ├── Empresa/       # Funcionalidades para empresas parceiras
│   ├── Governo/       # Funcionalidades governamentais
│   └── Profissional/  # Área para profissionais de saúde/educação
├── Controllers/       # Controllers públicos/autenticados
├── Models/            # Entidades do domínio
│   └── Enums/         # Enumerações do sistema (TipoPerfil, NivelSuporte, etc.)
├── Views/             # Razor Views organizadas por controller
└── ViewModels/        # ViewModels para formulários
```

### Sistema de Perfis (`TipoPerfil`)
O sistema usa perfis baseados em enum, não Roles do Identity:
- `Administrador` (0), `Mae` (1), `ProfissionalSaude` (2), `ProfissionalEducacao` (3), `Empresa` (4), `Governo` (5)

```csharp
// Verificação de admin nos controllers de área
private async Task<bool> IsAdmin()
{
    var user = await _userManager.GetUserAsync(User);
    return user?.TipoPerfil == TipoPerfil.Administrador;
}
```

### Principais Entidades e Relacionamentos
- `ApplicationUser` → `Child` (1:N - mãe tem filhos)
- `ApplicationUser` → `Post`, `Manejo`, `PostAcolhimento` (1:N)
- `Post` → `PostComment`, `PostAcolhimento` (1:N)
- `Child` → `School` (N:1 - opcional)
- `Manejo` pode ser validado por `ApplicationUser` (especialista)

## Padrões de Código

### Controllers
- Injeção de `ApplicationDbContext` e `ILogger<T>` via construtor
- Usar `User.FindFirstValue(ClaimTypes.NameIdentifier)` para obter ID do usuário
- `[Authorize]` para ações autenticadas; `[Area("Admin")]` para áreas
- Mensagens via `TempData["Mensagem"]` ou `TempData["Erro"]`

```csharp
// Padrão de criação com validação
[HttpPost]
[ValidateAntiForgeryToken]
[Authorize]
public async Task<IActionResult> Create([Bind("Campo1,Campo2")] Entidade item)
{
    ModelState.Remove("UserId"); // Remover campos definidos no servidor
    if (ModelState.IsValid)
    {
        item.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        item.DataCriacao = DateTime.UtcNow;
        // ...
    }
}
```

### Models
- Sempre usar `[Required]`, `[StringLength]`, `[Display(Name = "...")]` em português
- Propriedades de navegação como `virtual`
- Datas com `DateTime.UtcNow`
- Padrão de soft delete com `bool Ativo`

### DbContext
- Configurar relacionamentos em `OnModelCreating`
- Usar `DeleteBehavior.Restrict` para FK obrigatórias
- Usar `DeleteBehavior.SetNull` para FK opcionais

## Comandos de Desenvolvimento

```bash
# Executar o projeto (libera porta automaticamente)
./testar.sh [porta]  # padrão: 5000

# Comandos dotnet padrão
cd AUTistima
dotnet run --urls "http://localhost:5000"
dotnet build
dotnet ef migrations add NomeMigration
dotnet ef database update
```

## Convenções de UI/UX

- **Cores**: Salmon (`#F28B82`), tons suaves para acolhimento
- **Ícones**: Bootstrap Icons (`bi bi-*`)
- **Tom de mensagens**: Acolhedor e empático (`"Você não está sozinha! 💕"`)
- **Acessibilidade**: Skip links, labels descritivos, fonte Inter

## Fluxo de Autorização por Área

| Área | Perfis Permitidos | Verificação |
|------|-------------------|-------------|
| `/Admin/*` | `Administrador` | `IsAdmin()` manual no controller |
| `/Profissional/*` | `ProfissionalSaude`, `ProfissionalEducacao` | Verificar `TipoPerfil` |
| `/Empresa/*` | `Empresa` | Verificar `TipoPerfil` |
| `/Governo/*` | `Governo`, `Administrador` | Verificar `TipoPerfil` |

> **Nota**: O sistema não usa Authorization Policies do ASP.NET. A verificação é feita manualmente em cada controller de área.

## Funcionalidades em Desenvolvimento

As seguintes áreas possuem estrutura básica mas estão sendo expandidas:
- **Empresa/**: Portal para empresas parceiras (vagas PCD, selo "Empresa Amiga")
- **Governo/**: Dashboard para gestão pública de políticas
- **Profissional/**: Área para profissionais oferecerem serviços

## Observações Importantes

1. **Migrations automáticas**: Em dev, migrations são aplicadas automaticamente no startup (`Program.cs`)
2. **Usuário admin padrão**: `lorena@autistima.app.br` criado se não existir
3. **Conceito "Manejos"**: São "saberes não cientificizados" - conhecimento de vivência das mães, não prescrições médicas
4. **Central de Acolhimento**: Feed estilo rede social com sistema de "acolher" (like empático)
5. **Soft Delete**: Entidades usam `bool Ativo` ao invés de exclusão física

## Arquivos-Chave para Referência

| Arquivo | Propósito |
|---------|-----------|
| `Program.cs` | Configuração de DI, Identity, migrations automáticas |
| `Data/ApplicationDbContext.cs` | Schema, relacionamentos, configurações EF |
| `Models/ApplicationUser.cs` | Extensão do Identity com campos específicos |
| `Models/Enums/TipoPerfil.cs` | Enum central de perfis do sistema |
| `Controllers/AcolhimentoController.cs` | Exemplo de padrão CRUD com validação |
| `Areas/Admin/Controllers/AdminController.cs` | Exemplo de verificação de admin |
