using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class ConfirmEmailViewModel
    {
        [Required]
        [DisplayName("Token de confirmação")]
        public string Token { get; set; }
    }
}
