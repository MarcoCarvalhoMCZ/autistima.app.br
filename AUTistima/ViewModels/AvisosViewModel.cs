using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.ViewModels;

/// <summary>
/// ViewModel para a página de envio de avisos (Admin).
/// </summary>
public class AvisosIndexViewModel
{
    /// <summary>Histórico de broadcasts enviados.</summary>
    public List<BroadcastMessage> Historico { get; set; } = [];

    /// <summary>Formulário de novo aviso.</summary>
    public EnviarAvisoViewModel Formulario { get; set; } = new();

    /// <summary>Lista de usuários ativos para seleção individual.</summary>
    public List<SelectListItem> UsuariosDisponiveis { get; set; } = [];

    /// <summary>Totais por perfil para o preview antes do envio.</summary>
    public Dictionary<TipoPerfil, int> ContagemPorPerfil { get; set; } = [];

    public int TotalUsuariosAtivos { get; set; }
}

/// <summary>
/// Dados do formulário de envio de aviso.
/// </summary>
public class EnviarAvisoViewModel
{
    [Required(ErrorMessage = "Informe o título.")]
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a mensagem.")]
    [StringLength(1000, ErrorMessage = "Máximo 1000 caracteres.")]
    [Display(Name = "Mensagem")]
    public string Mensagem { get; set; } = string.Empty;

    [StringLength(255, ErrorMessage = "Máximo 255 caracteres.")]
    [Display(Name = "Link (opcional)")]
    public string? Link { get; set; }

    /// <summary>
    /// "Todos" | "Perfil" | "Selecionados"
    /// </summary>
    [Required(ErrorMessage = "Selecione o tipo de destino.")]
    [Display(Name = "Destinatários")]
    public string TipoDestino { get; set; } = "Todos";

    /// <summary>
    /// Perfil alvo quando TipoDestino == "Perfil".
    /// </summary>
    [Display(Name = "Perfil")]
    public TipoPerfil? PerfilDestino { get; set; }

    /// <summary>
    /// IDs dos usuários quando TipoDestino == "Selecionados".
    /// </summary>
    [Display(Name = "Usuários selecionados")]
    public List<string> UsuariosSelecionados { get; set; } = [];
}
