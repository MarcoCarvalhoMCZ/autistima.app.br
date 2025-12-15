using System.ComponentModel.DataAnnotations;
using AUTistima.Models.Enums;

namespace AUTistima.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "O nome completo é obrigatório.")]
    [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
    [Display(Name = "Nome Completo")]
    public string NomeCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar Senha")]
    [Compare("Password", ErrorMessage = "As senhas não conferem.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecione o tipo de perfil.")]
    [Display(Name = "Eu sou...")]
    public TipoPerfil TipoPerfil { get; set; }

    [StringLength(100)]
    [Display(Name = "Cidade")]
    public string? Cidade { get; set; }

    [StringLength(2)]
    [Display(Name = "Estado")]
    public string? Estado { get; set; }

    [Display(Name = "Li e concordo com o termo de consentimento")]
    [MustBeTrue(ErrorMessage = "Você precisa aceitar o termo de consentimento.")]
    public bool TermoConsentimento { get; set; }
}

public class MustBeTrueAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }
}
