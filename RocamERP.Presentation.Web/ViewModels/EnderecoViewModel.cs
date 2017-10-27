using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo para o campo é de 50 caracteres.")]
        public string Rua { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(30, ErrorMessage = "O tamanho máximo para o campo é de 30 caracteres.")]
        public string Bairro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int Numero { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo para o campo é de 50 caracteres.")]
        public string Complemento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string CidadeId { get; set; }
        public CidadeViewModel Cidade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public TipoEndereco TipoEndereco { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro} em {Cidade}";
        }
    }

    public enum TipoEndereco
    {
        Comercial,
        Residencial,
        Rural,
        Outro, 
    }

}