using System.Collections.Generic;
using Teleagendamento.Models.Enum;

namespace Teleagendamento.Models.Filtro
{
    public class ClinicaFilter
    {

        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public TipoStatus Status { get; set; }
    }
}
