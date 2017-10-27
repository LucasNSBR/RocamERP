using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class ClientePessoaFisicaViewModel : ClienteViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(11, ErrorMessage = "O tamanho máximo para o campo é de 11 caracteres.")]
        public string CPF { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(12, ErrorMessage = "O tamanho máximo para o campo é de 12 caracteres.")]
        public string RG { get; set; }
    }
}