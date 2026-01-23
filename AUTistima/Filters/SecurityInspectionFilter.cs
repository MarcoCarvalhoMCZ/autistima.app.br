using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Services;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace AUTistima.Filters
{
    public class SecurityInspectionFilter : IAsyncActionFilter
    {
        private static readonly string[] SuspiciousPatterns = new[]
        {
            @"<script",
            @"javascript:",
            @"\s+union\s+select\s+",
            @"^union\s+select\s+",
            @";\s*drop\s+table",
            @";\s*update\s+",
            @";\s*delete\s+from",
            @";\s*insert\s+into",
            @"xp_cmdshell",
            @"onload\s*=",
            @"onerror\s*=",
            @"alert\s*\(",
            @"eval\s*\("
        };

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Apenas verifica métodos de escrita
            var method = context.HttpContext.Request.Method.ToUpper();
            if (method == "POST" || method == "PUT" || method == "PATCH")
            {
                if (await InspectRequestAsync(context))
                {
                    // Bloqueia a requisição
                    context.Result = new BadRequestObjectResult(new { message = "Conteúdo malicioso detectado. Sua conta foi suspensa preventivamente." });
                    return;
                }
            }

            await next();
        }

        private async Task<bool> InspectRequestAsync(ActionExecutingContext context)
        {
            bool found = false;
            string details = "";

            try 
            {
                // 1. Verifica dados de formulário (Form Data)
                if (context.HttpContext.Request.HasFormContentType)
                {
                    var form = context.HttpContext.Request.Form; // Form já deve estar lido pelo ModelBinding
                    foreach (var key in form.Keys)
                    {
                        var value = form[key].ToString();
                        if (IsSuspicious(value, out string matchedPattern))
                        {
                            found = true;
                            details = $"Campo '{key}' contém padrão proibido: '{matchedPattern}'";
                            break;
                        }
                    }
                }

                // 2. Se não achou no Form, verifica Argumentos da Action (para APIs/JSON)
                if (!found && context.ActionArguments != null) 
                {
                     foreach (var arg in context.ActionArguments)
                     {
                         // Verifica strings diretas
                         if (arg.Value is string s && IsSuspicious(s, out string p))
                         {
                             found = true;
                             details = $"Argumento '{arg.Key}' contém padrão proibido: '{p}'";
                             break;
                         }
                         
                         // Poderíamos implementar reflexão recursiva aqui para objetos complexos,
                         // mas por performance vamos confiar que o FormCheck pega a maioria dos casos MVC
                         // e JSON simples strings.
                     }
                }

                if (found)
                {
                    var userManager = context.HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();
                    var activityService = context.HttpContext.RequestServices.GetService<IActivityTrackingService>();
                    var userPrincipal = context.HttpContext.User;

                    // Ação: Desativar Usuário e Logar
                    if (userManager != null && userPrincipal != null && userPrincipal.Identity != null && userPrincipal.Identity.IsAuthenticated)
                    {
                        var appUser = await userManager.GetUserAsync(userPrincipal);
                        if (appUser != null)
                        {
                            // Desativar usuário
                            appUser.Ativo = false;
                            // Adicionar bloqueio de data para garantir
                            appUser.LockoutEnd = DateTimeOffset.MaxValue;
                            appUser.LockoutEnabled = true;
                            
                            await userManager.UpdateAsync(appUser);
                            
                            // Logar atividade
                            if (activityService != null)
                            {
                                await activityService.RegistrarAtividadeComContexto(
                                    appUser.Id, 
                                    TipoAtividade.TentativaAtaque, 
                                    context.HttpContext, 
                                    "SecurityFilter", 
                                    null, 
                                    details
                                );
                            }
                        }
                    }
                    else
                    {
                         // Tentativa anônima - Logar se possível (mas sem User ID)
                         // Aqui apenas bloqueamos.
                    }
                    
                    return true;
                }
            }
            catch (Exception)
            {
                // Em caso de erro na análise, permite passar para não quebrar a aplicação (Fail Open)
                // O ideal seria Fail Closed, mas em produção sem testes extensivos, melhor não bloquear legítimos por erro de código nosso.
            }

            return false;
        }

        private bool IsSuspicious(string input, out string pattern)
        {
            pattern = string.Empty;
            if (string.IsNullOrEmpty(input)) return false;

            // Normalização básica para evitar bypass simples
            // var normalized = input.ToLowerInvariant(); // Regex já trata Case

            foreach (var p in SuspiciousPatterns)
            {
                if (Regex.IsMatch(input, p, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                {
                    pattern = p;
                    return true;
                }
            }
            return false;
        }
    }
}
