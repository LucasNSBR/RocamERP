using RocamERP.Presentation.Web.ViewModels.CidadeViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int EstadoId { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo para o campo é de 50 caracteres.")]
        [MinLength(3, ErrorMessage = "O tamanho mínimo para o campo é de 3 caracteres.")]
        public string Nome { get; set; }
        
        public ICollection<CidadeViewModel> Cidades { get; set; }

        public EstadoViewModel()
        {
            Cidades = new List<CidadeViewModel>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}