using AUTistima.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>
/// Filho(a) - criança/adolescente/adulto autista vinculado a uma mãe
/// </summary>
public class Child
{
    [Key]
    public int Id { get; set; }

    /// <summary>Código único gerado automaticamente no cadastro (ex: ALU-2026-000001)</summary>
    [StringLength(20)]
    [Display(Name = "Código do Estudante")]
    public string? CodigoUnico { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;
    
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }
    
    [Display(Name = "Nível de Suporte")]
    public NivelSuporte? NivelSuporte { get; set; }
    
    [Display(Name = "Possui diagnóstico formal?")]
    public bool PossuiDiagnostico { get; set; } = false;
    
    [Display(Name = "Data do Diagnóstico")]
    [DataType(DataType.Date)]
    public DateTime? DataDiagnostico { get; set; }
    
    [StringLength(200)]
    [Display(Name = "Escola")]
    public string? EscolaNome { get; set; }
    
    [Display(Name = "ID da Escola")]
    public int? EscolaId { get; set; }
    
    [Display(Name = "Possui PAE (Plano de Atendimento Educacional)?")]
    public bool PossuiPAE { get; set; } = false;
    
    [Display(Name = "Estratégias para Crises")]
    [DataType(DataType.MultilineText)]
    public string? EstrategiasCrise { get; set; }
    
    [Display(Name = "Observações")]
    [DataType(DataType.MultilineText)]
    public string? Observacoes { get; set; }

    /// <summary>Comorbidades registradas (flags — pode combinar múltiplas)</summary>
    [Display(Name = "Comorbidades")]
    public TipoComorbidade Comorbidades { get; set; } = TipoComorbidade.Nenhuma;

    /// <summary>Informações complementares sobre outras comorbidades não listadas</summary>
    [StringLength(500)]
    [Display(Name = "Outras Condições")]
    public string? OutrasCondicoes { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    // Chave estrangeira para a mãe ou responsável
    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    // Escola que realizou o cadastro
    [Display(Name = "Cadastrado pelo usuário (escola)")]
    public string? CadastradoPorEscolaUserId { get; set; }

    [ForeignKey("CadastradoPorEscolaUserId")]
    public virtual ApplicationUser? CadastradoPorEscolaUsuario { get; set; }

    // Escola (relacionamento opcional)
    [ForeignKey("EscolaId")]
    public virtual School? Escola { get; set; }

    // Registros do prontuário
    public virtual ICollection<RegistroEstudante> Registros { get; set; } = new List<RegistroEstudante>();

    // Solicitações de acesso ao perfil
    public virtual ICollection<SolicitacaoAcessoPerfil> SolicitacoesAcesso { get; set; } = new List<SolicitacaoAcessoPerfil>();
}
