using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teleagendamento.Models.Enum;

namespace Teleagendamento.Models
{
    public class Agendamento
    {
        public Agendamento()
        {
            Status = TipoAgendamento.AguardandoAtendimento;
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TipoAgendamento Status { get; set; }
    }
}
