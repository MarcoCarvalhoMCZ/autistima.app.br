namespace AUTistima.Models.Enums;

/// <summary>
/// Status de aprovação do perfil do usuário
/// </summary>
public enum StatusAprovacao
{
    Pendente = 0,      // Aguardando revisão
    Aprovado = 1,      // Perfil validado
    Rejeitado = 2      // Rejeitado por não atender requisitos
}
