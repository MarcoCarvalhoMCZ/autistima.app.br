# AUTistima - Instruções para Agentes de IA

## Identidade e UX
- Código, UI, comentários e commits sempre em pt-BR; foco mobile-first, acessível (WCAG) e PWA; evite depender de JS quando houver alternativa.
- Design sobre Bootstrap 5 com Razor; prefira Tag Helpers e HTML semântico, mantendo lógica fora das views.

## Arquitetura e Pastas
- Monolito ASP.NET Core 9 MVC com Identity; rotas em áreas por perfil em `AUTistima/Areas/{Perfil}` (Admin, Empresa, Governo, Mae, Profissional).
- Serviços e pipeline estão em [AUTistima/Program.cs](AUTistima/Program.cs): `SecurityInspectionFilter` global, SignalR em `/chatHub`, sessão habilitada, registros de AI/Push/Pânico/Estatísticas.
- Modelos e DbSets em [AUTistima/Data/ApplicationDbContext.cs](AUTistima/Data/ApplicationDbContext.cs); schema fixo `autistima_sa_sql` com seeds grandes (GlossaryTerms, Services CAPS Maceió). Não altere o schema.

## Dados e Migrations
- Soft delete via `Ativo`; não use DELETE físico. Filtre queries e carregue relacionamentos com `Include/ThenInclude` para evitar N+1.
- Migrations: `dotnet ef migrations add Nome` dentro de `AUTistima/`; `Program` aplica `Database.Migrate()` no startup (evite `database update` manual salvo instrução explícita, ex. guias do pânico).
- Perfis e usuários: startup garante admins `lorena@autistima.app.br` e `diretoria@sosdados.com.br` com senha resetada; rotas de login/logout definidas em Identity.

## Execução local
- Use sempre `./testar.sh [porta]` na raiz; o script libera a porta e roda `dotnet run --urls http://localhost:{porta}`.
- Connection string em `appsettings.Development.json`; static assets PWA via `MapStaticAssets` já configurado.

## Serviços chave
- `AIService` (Basic) em [AUTistima/Services/AIService.cs](AUTistima/Services/AIService.cs): sugestões com EF, sem chamadas externas; mantenha operações async e filtros por `Ativo`.
- `PanicService` em [AUTistima/Services/PanicService.cs](AUTistima/Services/PanicService.cs): cria/confirmar alertas e gera link WhatsApp usando `SystemConfiguration` (`WHATSAPP_NUMERO_PANICO`), incluindo dados da mãe/filhos.
- Push em [AUTistima/Services/PushNotificationService.cs](AUTistima/Services/PushNotificationService.cs): WebPush com chaves VAPID fixas; `EnviarComPushAsync` grava `Notification` e dispara push.
- Métricas em [AUTistima/Services/StatisticsService.cs](AUTistima/Services/StatisticsService.cs): `ActivityTrackingService` registra navegação/login; dashboards calculam contagens por período/perfil.

## Segurança
- `SecurityInspectionFilter` ([AUTistima/Filters/SecurityInspectionFilter.cs](AUTistima/Filters/SecurityInspectionFilter.cs)) bloqueia payload suspeito em POST/PUT/PATCH e desativa usuário via Identity; mantenha-o ativo e não burle os checks.
- Cookies/sessão já configurados; preserve padrões async e valide `TipoPerfil` nas controllers.

## Padrões de código e validação
- Controllers finos, delegando a Services; ViewModels em `AUTistima/ViewModels/` com DataAnnotations e mensagens de erro explícitas em pt-BR.
- Entidades ricas em `AUTistima/Models/`; relacionamentos com DeleteBehavior Restrict/SetNull (ex.: ApplicationUser, Child, Service) e flags `Ativo` para soft delete.

## Documentação e QA
- Testes manuais ficam em `TESTES_{FEATURE}.md` (checklists). Pânico possui guias em [QUICK_START_PANICO.md](QUICK_START_PANICO.md), [IMPLEMENTACAO_PANICO.md](IMPLEMENTACAO_PANICO.md) e [TESTES_PANICO.md](TESTES_PANICO.md).
- Em novas features, mantenha idioma, acessibilidade e estilo PWA; valide responsividade e fluxo sem JS.
