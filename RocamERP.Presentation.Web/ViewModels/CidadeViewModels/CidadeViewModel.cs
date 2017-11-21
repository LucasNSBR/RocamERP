using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels.CidadeViewModels
{
    public class CidadeViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int CidadeId { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O campo deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        [DisplayName("Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string EstadoId { get; set; }

        public EstadoViewModel Estado { get; set; }

        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }
        
        #region ViewModel Attributes
        public ICollection<SelectListItem> EstadosList { get; set; }
        #endregion

        public override string ToString()
        {
            return Nome;
        }

        public CidadeViewModel()
        {
            Enderecos = new List<EnderecoViewModel>();
        }
    }
}