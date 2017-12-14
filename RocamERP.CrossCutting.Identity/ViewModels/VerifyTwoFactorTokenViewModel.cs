using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class VerifyTwoFactorTokenViewModel
    {
        [Required]
        [DisplayName("Código de Verificação")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Provedor de verifição")]
        public string Provider { get; set; }
    }
}
