using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class VerifyCodeViewModel
    {
        [Required]
        [DisplayName("Código de Verificação")]
        public string Code { get; set; }
    }
}
