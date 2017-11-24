using RocamERP.Presentation.Web.ViewModels.CidadeViewModels;
using RocamERP.Presentation.Web.ViewModels.PessoaViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int EnderecoId { get; set; }

        [DisplayName("Rua")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo para o campo é de 50 caracteres.")]
        public string Rua { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O número de endereço não pode ser negativo.")]
        [DisplayName("Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int Numero { get; set; }

        [DisplayName("Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(30, ErrorMessage = "O tamanho máximo para o campo é de 30 caracteres.")]
        public string Bairro { get; set; }

        [DisplayName("Complemento")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo para o campo é de 50 caracteres.")]
        public string Complemento { get; set; }

        [DisplayName("Observação")]
        [MaxLength(1000, ErrorMessage = "O tamanho máximo para o campo é de 1000 caracteres.")]
        public string Observacao { get; set; }

        [DisplayName("CEP")]
        [DisplayFormat(DataFormatString = "{0:##.###-###}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(8, ErrorMessage = "O campo deve ter 8 caracteres.")]
        [MinLength(8, ErrorMessage = "O campo deve ter 8 caracteres.")]
        [Remote("ValidateCEP", "Enderecos", "Plataforma", AdditionalFields = "InitialCEPValue", ErrorMessage = "Já existe uma cidade com esse mesmo CEP.")]
        public string CEP { get; set; }

        [DisplayName("Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int CidadeId { get; set; }
        public CidadeViewModel Cidade { get; set; }

        [DisplayName("Pessoa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }

        [DisplayName("Tipo de endereço")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public TipoEndereco TipoEndereco { get; set; }

        #region ViewModel Attributes
        public IEnumerable<SelectListItem> CidadesList { get; set; }
        #endregion

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