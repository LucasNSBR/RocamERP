using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int ClienteId { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo para o campo é de 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo para o campo é de 1000 caracteres.")]
        public string Descricao { get; set; }

        [DisplayName("Contatos")]
        public virtual ICollection<ContatoViewModel> Contatos { get; set; }
        [DisplayName("Cheques")]
        public virtual ICollection<ChequeViewModel> Cheques { get; set; }
        [DisplayName("Endereços")]
        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }

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