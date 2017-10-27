using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        [MaxLength(50, ErrorMessage = "O tamanho máximo para o campo é de 50 caracteres.")]
        public string Nome { get; set; }
        public virtual ICollection<CidadeViewModel> Cidades { get; set; }

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