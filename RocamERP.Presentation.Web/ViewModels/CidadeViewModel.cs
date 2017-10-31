using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O campo deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(8, ErrorMessage = "O campo deve ter 8 caracteres.")]
        [MinLength(8, ErrorMessage = "O campo deve ter 8 caracteres.")]
        [Remote("ValidateCEP", "Cidades", "Plataforma", ErrorMessage = "Já existe uma cidade com esse mesmo CEP.")]
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