using Microsoft.AspNetCore.Identity;
using AUTistima.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>
/// Usuário do sistema AUTistima - extensão do Identity
/// </summary>
public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(150)]
    [Display(Name = "Nome Completo")]
    public string NomeCompleto { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Tipo de Perfil")]
    public TipoPerfil TipoPerfil { get; set; }
    
    [StringLength(500)]
    [Display(Name = "Sobre Mim")]
    public string? SobreMim { get; set; }
    
    [StringLength(255)]
    [Display(Name = "Foto de Perfil")]
    public string? FotoPerfilUrl { get; set; }
    
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
    
    // Endereço Completo
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
    public string? Bairro { get; set; }
    
    [StringLength(100)]
    public string? Cidade { get; set; }
    
    [StringLength(2)]
    public string? Estado { get; set; }

    // Termo de Consentimento
    [Display(Name = "Termo de Consentimento Aceito")]
    public bool TermoConsentimentoAceito { get; set; }

    [Display(Name = "Data do Aceite do Termo")]
    public DateTime? DataAceiteTermo { get; set; }
    
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    
    public bool Ativo { get; set; } = true;
    
    // Campos específicos para Empresas
    [StringLength(18)]
    [Display(Name = "CNPJ")]
    public string? CNPJ { get; set; }
    
    [StringLength(200)]
    [Display(Name = "Nome da Empresa")]
    public string? NomeEmpresa { get; set; }
    
    [Display(Name = "Empresa Amiga (selo de acessibilidade)")]
    public bool EmpresaAmiga { get; set; } = false;
    
    // Campos específicos para Profissionais de Saúde
    [StringLength(50)]
    [Display(Name = "Registro Profissional")]
    public string? RegistroProfissional { get; set; }
    
    [StringLength(50)]
    [Display(Name = "Matrícula Profissional (Educação)")]
    public string? MatriculaProfissional { get; set; }

    [Column("Especialidade")]
    [Display(Name = "Especialidade")]
    public int? EspecialidadeId { get; set; }

    [ForeignKey("EspecialidadeId")]
    public EspecialidadeProfissional? Especialidade { get; set; }
    
    // Status de Aprovação do Perfil
    [Display(Name = "Status de Aprovação")]
    public StatusAprovacao StatusAprovacao { get; set; } = StatusAprovacao.Pendente;
    
    [StringLength(500)]
    [Display(Name = "Motivo da Rejeição")]
    public string? MotivoRejeicao { get; set; }
    
    [Display(Name = "URL do Certificado/Diploma")]
    [StringLength(500)]
    public string? CertificadoUrl { get; set; }
    
    public DateTime? DataAprovacao { get; set; }
    
    public string? AprovadoPorAdminId { get; set; }
    
    // Navegações
    public virtual ICollection<Child> Filhos { get; set; } = new List<Child>();
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    public virtual ICollection<Manejo> Manejos { get; set; } = new List<Manejo>();
    public virtual ICollection<PostAcolhimento> Acolhimentos { get; set; } = new List<PostAcolhimento>();
    public virtual ICollection<Opportunity> OportunidadesCriadas { get; set; } = new List<Opportunity>();
    public virtual ICollection<Service> Servicos { get; set; } = new List<Service>();
    public virtual ICollection<Notification> Notificacoes { get; set; } = new List<Notification>();
    public virtual ICollection<ChatMessage> MensagensEnviadas { get; set; } = new List<ChatMessage>();
    public virtual ICollection<ChatMessage> MensagensRecebidas { get; set; } = new List<ChatMessage>();
}
