using RocamERP.Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class CadastroEstadualViewModel
    {
        [Key]
        [DisplayName("RG/Inscr. Estadual")]
        [MaxLength(14, ErrorMessage = "O tamanho máximo para o campo é 14 caracteres.")]
        [MinLength(11, ErrorMessage = "O tamanho mínimo para o campo é 11 caracteres.")]
        [Remote("ValidateCadastroEstadual", "Pessoas", ErrorMessage = "O número de documento já está em uso.")]
        public string NumeroDocumento { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public TipoCadastroEstadual TipoCadastroEstadual { get; set; }

        [Required]
        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }
}