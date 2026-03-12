using AUTistima.Data;
using AUTistima.Models;

namespace AUTistima.Services;

public class AuditService : IAuditService
{
    private readonly ApplicationDbContext _context;

    public AuditService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task RegistrarAsync(string? userId, string acao, string recurso, string? ipAddress = null, string? detalhes = null)
    {
        var ev = new AuditEvent
        {
            UserId = userId,
            Acao = acao,
            Recurso = recurso,
            IpAddress = ipAddress,
            Detalhes = detalhes,
            Data = DateTime.UtcNow
        };
        _context.AuditEvents.Add(ev);
        await _context.SaveChangesAsync();
    }
}
