using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O campo deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }
        
        [DisplayName("CEP")]
        [DisplayFormat(DataFormatString = "{0:##.###-###}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(8, ErrorMessage = "O campo deve ter 8 caracteres.")]
        [MinLength(8, ErrorMessage = "O campo deve ter 8 caracteres.")]
        [Remote("ValidateCEP", "Cidades", "Plataforma", ErrorMessage = "Já existe uma cidade com esse mesmo CEP.")]
        public string CEP { get; set; }

        [DisplayName("Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string EstadoId { get; set; }

        [DisplayName("Estado")]
        public EstadoViewModel Estado { get; set; }

        [DisplayName("Endereços")]
        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }

        public ICollection<SelectListItem> EstadosList { get; private set; }
        public void LoadEstadosList(IEnumerable<EstadoViewModel> estados)
        {
            ICollection<SelectListItem> estadosList = new List<SelectListItem>();
            foreach(var estado in estados)
            {
                EstadosList.Add(new SelectListItem()
                {
                    Text = estado.Nome,
                    Value = estado.Nome,
                }); 
            }
        }

        public override string ToString()
        {
            return Nome;
        }

        public CidadeViewModel()
        {
            EstadosList = new List<SelectListItem>();
        }
    }
}