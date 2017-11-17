using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class BancoViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int BancoId { get; set; }

        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Código de Compensação")]
        [MaxLength(4, ErrorMessage = "O tamanho máximo é de 4 caracteres.")]
        public int CodigoCompensacao { get; set; }

        public virtual ICollection<ChequeViewModel> Cheques { get; set; }

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