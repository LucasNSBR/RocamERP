using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [DisplayName("Endereço de e-mail")]
        [EmailAddress(ErrorMessage = "O campo deve estar no formato de endereço de e-mail.")]
        public string Email { get; set; }
    }
}
