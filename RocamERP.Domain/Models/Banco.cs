using System.Collections.Generic;

namespace RocamERP.Domain.Models
{
    public class Banco
    {
        public int BancoId { get; set; }
        public string Nome { get; set; }
        public int CodigoCompensacao { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }

        public Banco()
        {
            Cheques = new List<Cheque>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}