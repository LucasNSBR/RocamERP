using System;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class ChequeViewModel
    {
        [Key]
        public int ChequeId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string BancoId { get; set; }
        public BancoViewModel Banco { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo para o campo é 10 caracteres.")]
        public string Agencia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo para o campo é 10 caracteres.")]
        public string ContaCorrente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        [MaxLength(1000, ErrorMessage = "O tamanho máximo para o campo é 1000 caracteres.")]
        public string Observacao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public SituacaoCheque SituacaoCheque { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public DateTime DataRecebimento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [Range(0, 100000, ErrorMessage = "O valor deve ser entre 0 e 100.000.")]
        public decimal Valor { get; set; }
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