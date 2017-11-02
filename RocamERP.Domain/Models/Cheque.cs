using System;

namespace RocamERP.Domain.Models
{
    public class Cheque
    {
        public int ChequeId { get; set; }

        public string BancoId { get; set; }
        public virtual Banco Banco { get; set; }
        
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Observacao { get; set; }

        public virtual SituacaoCheque SituacaoCheque { get; set; }

        public DateTime DataRecebimento { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
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