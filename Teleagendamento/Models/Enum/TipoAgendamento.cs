using System.ComponentModel.DataAnnotations;

namespace Teleagendamento.Models.Enum
{
    public enum TipoAgendamento
    {
        [Display(Name = "Aguardando Atendimento")]
        AguardandoAtendimento = 1,
        [Display(Name = "Atendido")]
        Atendido = 2,
        [Display(Name = "Não Compareceu")]
        NaoCompareceu = 3,
        [Display(Name = "Cancelado Pelo Usuário")]
        CanceladoPeloUsuario = 4,
        [Display(Name = "Cancelado Pela Clínica")]
        CanceladoPelaClinica = 5,
    }
}
