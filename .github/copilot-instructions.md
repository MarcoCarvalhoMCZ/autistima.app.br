# AUTistima - Instruções para Agentes de IA

## Visão Geral e Identidade
Você está atuando no projeto **AUTistima**, uma plataforma web monolítica focada em acessibilidade e suporte à comunidade autista.
- **Idioma:** Todo o código, comentários, commits e UI devem estar em **Português (pt-BR)**.
- **Design:** Mobile-first, acessível (WCAG), PWA. Funciona sem JS quando possível.

## Stack Tecnológica
- **Backend:** ASP.NET Core 9 (MVC)
- **Dados:** Entity Framework Core 9 + SQL Server (`autistima_sa_sql` schema)
- **Frontend:** Bootstrap 5, Razor Views, SignalR (chat)
- **Infra:** Docker ready (mas executado localmente via script)

## Arquitetura e Organização
O projeto segue o padrão MVC com separação por **Areas** para diferentes perfis de usuário:
- **Diretórios Chave:**
  - `AUTistima/Areas/{Perfil}/`: Controllers/Views específicos (`Admin`, `Empresa`, `Governo`, `Mae`, `Profissional`).
  - `AUTistima/Models/`: Entidades de domínio ricas (não anêmicas).
  - `AUTistima/Services/`: Lógica de negócios pesada (`AIService`, `PanicService`).
  - `AUTistima/wwwroot/`: Static assets (JS/CSS isolados).

### Modelos Críticos
- **`ApplicationUser`**: Estende `IdentityUser`. Centraliza dados de todos os perfis (`TipoPerfil`, `CPF`, `CNPJ`).
- **Relacionamentos**:
  - `Child` -> `ApplicationUser` (Pai/Mãe)
  - `School` -> `Child` (Muitos-para-Muitos ou Um-para-Muitos dependendo do contexto, verificar `Child.EscolaId`)

## Regras de Banco de Dados (EF Core)
1. **Schema**: Todas as tabelas residem no schema `autistima_sa_sql`.
2. **Soft Delete**: NUNCA execute `DELETE` físico. Use a propriedade `Ativo = false` e filtre queries.
   - *Exceção*: Dados transientes ou logs se especificamente solicitado.
3. **Performance**: Utilize `.Include()` e `.ThenInclude()` para carregar relacionamentos (Eager Loading) e evitar N+1 em Views.
4. **Migrations**:
   - Crie: `dotnet ef migrations add NomeDaMudanca` (na pasta `AUTistima/`)
   - Não aplique manualmente (`database update`). O `Program.cs` aplica no startup.

## Workflow de Desenvolvimento
- **Execução**: SEMPRE use `./testar.sh [porta]` na raiz.
  - Este script gerencia processos zumbis e portas bloqueadas (padrão 5000).
  - Não use `dotnet run` diretamente se possível.
- **Autenticação**:
  - Usuário Seed: `lorena@autistima.app.br` (Senha definida no seed/config).
  - Verifique `User.Identity.IsAuthenticated` e claims de `TipoPerfil`.

## Padrões de Código
- **Controllers**: Mantenha finos. Delegue lógica complexa para `Services`.
- **Async/Await**: Obrigatório em todas as operações de I/O (BD, API ext).
- **Injeção de Dependência**: Registre novos serviços em `Program.cs`. Use Scoped por padrão.
- **Tratamento de Erros**: Não engula exceções. Use `TempData["Mensagem"]` para feedback visual simples ao usuário.
- **Views**: Use Tag Helpers (`asp-controller`, `asp-action`). Evite lógica C# complexa no Razor.

## Padrões de Interface e Validação (ViewModels)
- **Localização**: `AUTistima/ViewModels/`
- **Nomenclatura**: Sufixo `ViewModel` (ex: `RegisterViewModel`).
- **Validação**:
  - Use DataAnnotations (`[Required]`, `[StringLength]`, etc.).
  - **Mensagens de Erro**: SEMPRE em pt-BR explícito (ex: `ErrorMessage = "O nome é obrigatório."`).
  - Crie atributos customizados se necessário (ex: `[MustBeTrue]`) no mesmo arquivo ou em `Extensions/`.
- **Uso**: Controllers devem receber ViewModels, validar `ModelState.IsValid` e retornar a View com o ViewModel em caso de erro.

## Estratégia de Testes e QA
O projeto prioriza testes manuais guiados e acessibilidade visual.
- **Documentação de Testes**: Crie/Atualize arquivos `TESTES_{FEATURE}.md` na raiz.
  - Siga o formato checklist (`- [ ] Cenario`).
  - Cubra: Autenticação (Quem vê o quê?), Responsividade (Mobile vs Desktop) e Fluxos de Erro.
- **Testes Manuais**:
  - Sempre verifique a interface em larguras móveis (DevTools).
  - Teste fluxos com javascript desabilitado quando aplicável (Progressive Enhancement).

## Integrações
- **IA/ML**: `AIService` para sugestões (Manejos, Termos).
- **Real-time**: `ChatHub` (SignalR) para mensagens instantâneas.
- **Notificações**: `PushNotificationService` (Web Push) e `NotificationService` (Interno).

## O que NÃO fazer
- Não criar repositórios genéricos (Use `ApplicationDbContext` direto ou Services específicos).
- Não usar `ViewBag` excessivamente (Prefira ViewModels tipados).
- Não misturar inglês e português (Mantenha consistência em pt-BR).
