using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{ 
    public class ContatoViewModel
    {
        [Key]
        public int ContatoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo é 100 caracteres.")]
        public string Observacao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public TipoContato TipoContato { get; set; }

        public override string ToString()
        {
            return Observacao;
        }
    }

    public enum TipoContato
    {
        Residencial,
        Comercial,
        Telefone,
        WhatsApp,
        Email,
    }
}