using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Endereço de e-mail")]
        [EmailAddress(ErrorMessage = "O campo deve estar no formato de endereço de e-mail.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Senha")]
        [StringLength(maximumLength: 24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 24 caracteres.")]
        public string Password { get; set; }

        [Required]
        [DisplayName]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
