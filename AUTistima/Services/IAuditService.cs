using AUTistima.Models;

namespace AUTistima.Services;

public interface IAuditService
{
    Task RegistrarAsync(string? userId, string acao, string recurso, string? ipAddress = null, string? detalhes = null);
}
