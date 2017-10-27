using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo 8 caracteres.")]
        public string CEP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string EstadoId { get; set; }
        public EstadoViewModel Estado { get; set; }

        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }
    
        public CidadeViewModel()
        {
            Enderecos = new List<EnderecoViewModel>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}