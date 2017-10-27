using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public abstract class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo para o campo é de 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo para o campo é de 1000 caracteres.")]
        public string Descricao { get; set; }

        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }
        public virtual ICollection<ContatoViewModel> Contatos { get; set; }
        public virtual ICollection<ChequeViewModel> Cheques { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public ClienteViewModel()
        {
            Enderecos = new List<EnderecoViewModel>();
            Contatos = new List<ContatoViewModel>();
            Cheques = new List<ChequeViewModel>();
        }
    }
}