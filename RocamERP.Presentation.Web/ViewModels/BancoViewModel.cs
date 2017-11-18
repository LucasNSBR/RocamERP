using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class BancoViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int BancoId { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Código de Compensação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [Range(0, 9999, ErrorMessage = "O tamanho máximo é de 4 caracteres e o valor não pode ser negativo.")]
        [Remote("ValidateCodigoBanco", "Bancos", "Plataforma", ErrorMessage = "Já existe um banco com esse código de compensação.")]
        public int CodigoCompensacao { get; set; }

        public ICollection<ChequeViewModel> Cheques { get; set; }

        public BancoViewModel()
        {
            Cheques = new List<ChequeViewModel>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}