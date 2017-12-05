using RocamERP.Presentation.Web.ViewModels.PessoaViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class ChequeViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int ChequeId { get; set; }

        [DisplayName("Banco")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int BancoId { get; set; }
        public BancoViewModel Banco { get; set; }

        [DisplayName("Agência")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo para o campo é 10 caracteres.")]
        public string Agencia { get; set; }

        [DisplayName("Conta Corrente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo para o campo é 10 caracteres.")]
        public string ContaCorrente { get; set; }

        [DisplayName("Número do Cheque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(7, ErrorMessage = "O tamanho máximo para o campo é 7 caracteres.")]
        public string NumeroCheque { get; set; }

        [DisplayName("Proprietário")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }

        [DisplayName("Observações")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Não registrado.")]
        [MaxLength(1000, ErrorMessage = "O tamanho máximo para o campo é 1000 caracteres.")]
        public string Observacao { get; set; }

        [DisplayName("Situação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public SituacaoCheque SituacaoCheque { get; set; }

        //[DataType(DataType.Date)]
        [DisplayName("Data de Recebimento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRecebimento { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Vencimento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }

        //[DataType(DataType.Date)]
        [DisplayName("Data de Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ConvertEmptyStringToNull = true, ApplyFormatInEditMode = true, NullDisplayText = "Não registrado.")]
        public DateTime? DataPagamento { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [Range(1, 100000, ErrorMessage = "O valor deve ser entre 1R$ e 100.000R$.")]
        public decimal Valor { get; set; }

        #region ViewModel Attributes
        public IEnumerable<SelectListItem> BancosList { get; set; }
        public IEnumerable<SelectListItem> PessoasList { get; set; }
        #endregion
    }

    public enum SituacaoCheque 
    {
        Bloqueado,
        Negociado, 
        Compensado, 
        Devolvido,
        Sustado,
        Repassado,
        SemFundos,
    }
}