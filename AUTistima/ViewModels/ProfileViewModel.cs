using System.ComponentModel.DataAnnotations;
using AUTistima.Models.Enums;

namespace AUTistima.ViewModels;

/// <summary>
/// ViewModel para edição do perfil do usuário
/// </summary>
public class ProfileViewModel
{
    public string Id { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Nome completo é obrigatório")]
    [StringLength(150)]
    [Display(Name = "Nome Completo")]
    public string NomeCompleto { get; set; } = string.Empty;
    
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;
    
    [Phone]
    [Display(Name = "Telefone")]
    public string? PhoneNumber { get; set; }
    
    [Display(Name = "Tipo de Perfil")]
    public TipoPerfil TipoPerfil { get; set; }
    
    [StringLength(500)]
    [Display(Name = "Sobre Mim")]
    [DataType(DataType.MultilineText)]
    public string? SobreMim { get; set; }
    
    // Dados Pessoais
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }
    
    [StringLength(14)]
    [Display(Name = "CPF")]
    public string? CPF { get; set; }
    
    [StringLength(12)]
    [Display(Name = "RG")]
    public string? RG { get; set; }
    
    // Endereço
    [StringLength(9)]
    [Display(Name = "CEP")]
    public string? CEP { get; set; }
    
    [StringLength(200)]
    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Número")]
    public string? NumeroEndereco { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Complemento")]
    public string? Complemento { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Bairro")]
    public string? Bairro { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Cidade")]
    public string? Cidade { get; set; }
    
    [StringLength(2)]
    [Display(Name = "Estado")]
    public string? Estado { get; set; }
    
    // Campos específicos para Empresas
    [StringLength(18)]
    [Display(Name = "CNPJ")]
    public string? CNPJ { get; set; }
    
    [StringLength(200)]
    [Display(Name = "Nome da Empresa")]
    public string? NomeEmpresa { get; set; }
    
    // Campos específicos para Profissionais
    [StringLength(50)]
    [Display(Name = "Registro Profissional (CRM, CRP, CRN, etc.)")]
    public string? RegistroProfissional { get; set; }
    
    [StringLength(50)]
    [Display(Name = "Matrícula Profissional (Educação)")]
    public string? MatriculaProfissional { get; set; }
    
    [Display(Name = "Especialidade")]
    public int? EspecialidadeId { get; set; }
    
    [Display(Name = "Foto de Perfil (URL)")]
    public string? FotoPerfilUrl { get; set; }
}

/// <summary>
/// ViewModel para alteração de senha
/// </summary>
public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "A senha atual é obrigatória")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha Atual")]
    public string SenhaAtual { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "A nova senha é obrigatória")]
    [StringLength(100, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Nova Senha")]
    public string NovaSenha { get; set; } = string.Empty;
    
    [DataType(DataType.Password)]
    [Display(Name = "Confirmar Nova Senha")]
    [Compare("NovaSenha", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmarSenha { get; set; } = string.Empty;
}
