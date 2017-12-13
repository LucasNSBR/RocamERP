using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DisplayName("Senha antiga")]
        [StringLength(maximumLength: 24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 24 caracteres.")]
        public string OldPassword { get; set; }

        [Required]
        [DisplayName("Nova senha")]
        [StringLength(maximumLength: 24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 24 caracteres.")]
        public string NewPassword { get; set; }

        [Required]
        [DisplayName("Confirme a nova senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmNewPassword { get; set; }
    }
}
