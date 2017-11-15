using RocamERP.Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class CadastroNacionalViewModel
    {
        [Key]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Não cadastrado")]
        [DisplayName("CPF/CNPJ")]
        [MaxLength(14, ErrorMessage = "O tamanho máximo para o campo é 14 caracteres.")]
        [MinLength(11, ErrorMessage = "O tamanho mínimo para o campo é 11 caracteres.")]
        [Remote("ValidateCadastroNacional", "Pessoas", ErrorMessage = "O campo deve ter 11 ou 14 caracteres.")]
        public string NumeroDocumento { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public TipoCadastroNacional TipoCadastroNacional { get; set; }

        [Required]
        public int PessoaId { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }
}