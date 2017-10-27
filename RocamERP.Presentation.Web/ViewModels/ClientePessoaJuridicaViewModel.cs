using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class ClientePessoaJuridicaViewModel : ClienteViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(14, ErrorMessage = "O tamanho máximo para o campo é de 14 caracteres.")]
        public string CNPJ { get; set; }

        [MaxLength(9, ErrorMessage = "O tamanho máximo para o campo é de 9 caracteres.")]
        public string InscricaoEstadual { get; set; }
    }
}