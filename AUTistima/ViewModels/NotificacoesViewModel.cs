using System.ComponentModel.DataAnnotations;
using AUTistima.Models;
using AUTistima.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AUTistima.ViewModels;

public class NotificacoesIndexViewModel
{
    public List<Notification> Notificacoes { get; set; } = new();
    public EnviarNotificacaoViewModel Envio { get; set; } = new();
    public List<SelectListItem> DestinatariosDisponiveis { get; set; } = new();
    public bool PodeEnviarEntrePerfis { get; set; }
    public string PerfilDestinatarioLabel { get; set; } = string.Empty;

    // --- Campos exclusivos do administrador ---
    public bool IsAdmin { get; set; }
    public EnviarAvisoAdminViewModel EnvioAdmin { get; set; } = new();
    /// <summary>Todos os usuários ativos agrupados por perfil, para o admin.</summary>
    public Dictionary<TipoPerfil, List<SelectListItem>> UsuariosPorPerfil { get; set; } = new();
    public Dictionary<TipoPerfil, int> ContagemPorPerfil { get; set; } = new();
    public int TotalUsuariosAtivos { get; set; }
}

public class EnviarAvisoAdminViewModel
{
    [Required(ErrorMessage = "Informe o título.")]
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a mensagem.")]
    [StringLength(1000, ErrorMessage = "Máximo 1000 caracteres.")]
    [Display(Name = "Mensagem")]
    public string Mensagem { get; set; } = string.Empty;

    [StringLength(255)]
    [Display(Name = "Link (opcional)")]
    public string? Link { get; set; }

    /// <summary>"Todos" | "Perfil" | "Selecionados"</summary>
    [Required]
    public string TipoDestino { get; set; } = "Todos";

    [Display(Name = "Perfil")]
    public TipoPerfil? PerfilDestino { get; set; }

    [Display(Name = "Usuários selecionados")]
    public List<string> UsuariosSelecionados { get; set; } = [];
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