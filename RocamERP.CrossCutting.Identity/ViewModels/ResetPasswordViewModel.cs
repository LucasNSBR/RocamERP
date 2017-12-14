using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DisplayName("Código de redefinição")]
        public string ResetCode { get; set; }

        [Required]
        [DisplayName("Nova Senha")]
        [StringLength(maximumLength: 24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 24 caracteres.")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirmar Nova Senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
