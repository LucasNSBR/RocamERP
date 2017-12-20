using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class ExternalRegisterViewModel
    {
        [DisplayName("Provedor")]
        public string ProviderName { get; set; }

        [Required]
        [DisplayName("Nome")]
        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 30 caracteres.")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Sobrenome")]
        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 30 caracteres.")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Idade")]
        [Range(minimum: 16, maximum: 80, ErrorMessage = "A idade deve ser um número válido.")]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        public ExternalRegisterViewModel()
        {

        }

        public ExternalRegisterViewModel(string providerName, string email)
        {
            ProviderName = providerName;
            Email = email;
        }
    }
}
