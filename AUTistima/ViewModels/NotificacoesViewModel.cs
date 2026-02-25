using System.ComponentModel.DataAnnotations;
using AUTistima.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AUTistima.ViewModels;

public class NotificacoesIndexViewModel
{
    public List<Notification> Notificacoes { get; set; } = new();
    public EnviarNotificacaoViewModel Envio { get; set; } = new();
    public List<SelectListItem> DestinatariosDisponiveis { get; set; } = new();
    public bool PodeEnviarEntrePerfis { get; set; }
    public string PerfilDestinatarioLabel { get; set; } = string.Empty;
}

public class EnviarNotificacaoViewModel
{
    [Required(ErrorMessage = "Selecione um destinatário.")]
    [Display(Name = "Destinatário")]
    public string DestinatarioId { get; set; } = string.Empty;

    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A mensagem é obrigatória.")]
    [StringLength(500, ErrorMessage = "A mensagem deve ter no máximo 500 caracteres.")]
    [Display(Name = "Mensagem")]
    public string Mensagem { get; set; } = string.Empty;

    [StringLength(255, ErrorMessage = "O link deve ter no máximo 255 caracteres.")]
    [Display(Name = "Link (opcional)")]
    public string? Link { get; set; }
}