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
        [DisplayName("Nome")]
        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 30 caracteres.")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Nome")]
        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 30 caracteres.")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Idade")]
        [Range(minimum: 16, maximum: 80, ErrorMessage = "A idade deve ser um número válido.")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Senha")]
        [StringLength(maximumLength: 24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 24 caracteres.")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirmar senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
