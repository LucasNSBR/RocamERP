using RocamERP.Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class CadastroEstadualViewModel
    {
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Não cadastrado")]
        [DisplayName("RG/Inscr. Estadual")]
        [MaxLength(14, ErrorMessage = "O tamanho máximo para o campo é 13 caracteres.")]
        [MinLength(11, ErrorMessage = "O tamanho mínimo para o campo é 11 caracteres.")]
        [Remote("ValidateCadastroEstadual", "Pessoas", ErrorMessage = "O número de documento já está em uso.")]
        public string NumeroDocumento { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public TipoCadastroEstadual TipoCadastroEstadual { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }
}