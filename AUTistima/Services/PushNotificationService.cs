using WebPush;
using AUTistima.Data;
using AUTistima.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTistima.Services;

/// <summary>
/// Interface para serviço de Push Notifications
/// </summary>
public interface IPushNotificationService
{
    /// <summary>
    /// Envia uma notificação push para um usuário específico
    /// </summary>
    Task<int> EnviarParaUsuarioAsync(string userId, string titulo, string mensagem, string? url = null);
    
    /// <summary>
    /// Envia uma notificação push para todos os usuários
    /// </summary>
    Task<int> EnviarParaTodosAsync(string titulo, string mensagem, string? url = null);
    
    /// <summary>
    /// Envia uma notificação push para múltiplos usuários
    /// </summary>
    Task<int> EnviarParaUsuariosAsync(IEnumerable<string> userIds, string titulo, string mensagem, string? url = null);
    
    /// <summary>
    /// Remove subscriptions inativas/expiradas
    /// </summary>
    Task<int> LimparSubscriptionsInativasAsync();
}

/// <summary>
/// Implementação do serviço de Push Notifications usando WebPush
/// </summary>
public class PushNotificationService : IPushNotificationService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<PushNotificationService> _logger;
    private readonly WebPushClient _webPushClient;
    private readonly VapidDetails _vapidDetails;

    // Chaves VAPID - Em produção, mover para appsettings.json ou secrets
    private const string VAPID_SUBJECT = "mailto:contato@autistima.app.br";
    private const string VAPID_PUBLIC_KEY = "BOKb5iYep92uFFR-z-HIYYEUQK2A3TKlKKYxcTl-kSIIsQD9N-emBMcN72ybhyPd_Fg8mLaS2k4RLUuRyJcSkFM";
    private const string VAPID_PRIVATE_KEY = "X1AirWJ1vWVUGyUWaLWa45omLgAmTYPhF6jnNDphi0s";

    public PushNotificationService(
        ApplicationDbContext context,
        ILogger<PushNotificationService> logger)
    {
        _context = context;
        _logger = logger;
        _webPushClient = new WebPushClient();
        _vapidDetails = new VapidDetails(VAPID_SUBJECT, VAPID_PUBLIC_KEY, VAPID_PRIVATE_KEY);
    }

    /// <summary>
    /// Obtém a chave pública VAPID para uso no frontend
    /// </summary>
    public static string GetPublicKey() => VAPID_PUBLIC_KEY;

    public async Task<int> EnviarParaUsuarioAsync(string userId, string titulo, string mensagem, string? url = null)
    {
        var subscriptions = await _context.PushSubscriptions
            .Where(p => p.UserId == userId && p.Ativo)
            .ToListAsync();

        return await EnviarParaSubscriptionsAsync(subscriptions, titulo, mensagem, url);
    }

    public async Task<int> EnviarParaTodosAsync(string titulo, string mensagem, string? url = null)
    {
        var subscriptions = await _context.PushSubscriptions
            .Where(p => p.Ativo)
            .ToListAsync();

        return await EnviarParaSubscriptionsAsync(subscriptions, titulo, mensagem, url);
    }

    public async Task<int> EnviarParaUsuariosAsync(IEnumerable<string> userIds, string titulo, string mensagem, string? url = null)
    {
        var subscriptions = await _context.PushSubscriptions
            .Where(p => userIds.Contains(p.UserId) && p.Ativo)
            .ToListAsync();

        return await EnviarParaSubscriptionsAsync(subscriptions, titulo, mensagem, url);
    }

    private async Task<int> EnviarParaSubscriptionsAsync(
        List<Models.PushSubscription> subscriptions, 
        string titulo, 
        string mensagem, 
        string? url)
    {
        if (!subscriptions.Any())
        {
            _logger.LogDebug("Nenhuma subscription encontrada para enviar push");
            return 0;
        }

        var payload = System.Text.Json.JsonSerializer.Serialize(new
        {
            title = titulo,
            body = mensagem,
            icon = "/icons/icon-192x192.png",
            badge = "/icons/icon-72x72.png",
            tag = $"autistima-{DateTime.UtcNow.Ticks}",
            data = new { url = url ?? "/" }
        });

        var enviados = 0;
        var subscriptionsParaRemover = new List<Models.PushSubscription>();

        foreach (var sub in subscriptions)
        {
            try
            {
                var pushSubscription = new WebPush.PushSubscription(
                    sub.Endpoint,
                    sub.P256dh,
                    sub.Auth
                );

                await _webPushClient.SendNotificationAsync(pushSubscription, payload, _vapidDetails);
                
                sub.UltimoEnvio = DateTime.UtcNow;
                enviados++;
                
                _logger.LogDebug("Push enviado para subscription {Id}", sub.Id);
            }
            catch (WebPushException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Gone || 
                                               ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Subscription expirou ou foi removida pelo usuário
                _logger.LogWarning("Subscription {Id} expirada, marcando como inativa", sub.Id);
                subscriptionsParaRemover.Add(sub);
            }
            catch (WebPushException ex)
            {
                _logger.LogError(ex, "Erro ao enviar push para subscription {Id}: {StatusCode}", 
                    sub.Id, ex.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao enviar push para subscription {Id}", sub.Id);
            }
        }

        // Marcar subscriptions expiradas como inativas
        foreach (var sub in subscriptionsParaRemover)
        {
            sub.Ativo = false;
        }

        if (subscriptionsParaRemover.Any() || enviados > 0)
        {
            await _context.SaveChangesAsync();
        }

        _logger.LogInformation("Push enviado para {Enviados}/{Total} subscriptions", 
            enviados, subscriptions.Count);

        return enviados;
    }

    public async Task<int> LimparSubscriptionsInativasAsync()
    {
        // Remove subscriptions inativas há mais de 30 dias
        var limite = DateTime.UtcNow.AddDays(-30);
        
        var subscriptionsParaRemover = await _context.PushSubscriptions
            .Where(p => !p.Ativo && p.DataCriacao < limite)
            .ToListAsync();

        if (subscriptionsParaRemover.Any())
        {
            _context.PushSubscriptions.RemoveRange(subscriptionsParaRemover);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Removidas {Count} subscriptions inativas", subscriptionsParaRemover.Count);
        }

        return subscriptionsParaRemover.Count;
    }
}

/// <summary>
/// Extensões para facilitar o envio de push notifications
/// </summary>
public static class PushNotificationExtensions
{
    /// <summary>
    /// Envia push notification junto com a notificação interna
    /// </summary>
    public static async Task EnviarComPushAsync(
        this IPushNotificationService pushService,
        ApplicationDbContext context,
        string userId,
        string titulo,
        string mensagem,
        TipoNotificacao tipo,
        string? url = null)
    {
        // Criar notificação interna
        var notificacao = new Notification
        {
            UserId = userId,
            Titulo = titulo,
            Mensagem = mensagem,
            Tipo = tipo,
            Link = url,
            DataCriacao = DateTime.UtcNow,
            Lida = false
        };
        
        context.Notifications.Add(notificacao);
        await context.SaveChangesAsync();

        // Enviar push notification
        await pushService.EnviarParaUsuarioAsync(userId, titulo, mensagem, url);
    }
}
