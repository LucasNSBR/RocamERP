using System;

namespace RocamERP.Models
{
    public class Cheque
    {
        public int ChequeId { get; set; }

        public int BancoId { get; set; }
        public Banco Banco { get; set; }
        
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Observacao { get; set; }

        public SituacaoCheque SituacaoCheque { get; set; }

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