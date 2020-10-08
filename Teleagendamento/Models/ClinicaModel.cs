using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teleagendamento.Libraries.Lang;
using Teleagendamento.Models.Enum;

namespace Teleagendamento.Models
{
    public class Clinica
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        [MaxLength(200)]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        [MaxLength(200)]
        public string CNPJ { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        [MaxLength(200)]
        public string Telefone { get; set; }
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        public int VagasDiarias { get; set; }
        public TipoStatus Status { get; set; }
    }

    public class Endereco
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        [MaxLength(200)]
        public string Logradouro { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        [RegularExpression("[0-9]{5}-[0-9]{3}", ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E002")]
        public string CEP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        [MaxLength(100)]
        public string Bairro { get; set; }
        public TipoEstado Estado { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Mensagem_pt_BR), ErrorMessageResourceName = "MSG_E001")]
        [MaxLength(100)]
        public string Cidade { get; set; }
    }
}
