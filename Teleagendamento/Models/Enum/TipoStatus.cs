using System.ComponentModel.DataAnnotations;

namespace Teleagendamento.Models.Enum
{
    public enum TipoStatus
    {
        Todos = 0,
        [Display(Name = "Ativo")]
        Ativo = 1,
        [Display(Name = "Inativo")]
        Inativo = 2
    }
}
