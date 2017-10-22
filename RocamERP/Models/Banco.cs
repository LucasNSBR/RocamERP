using System.Collections.Generic;

namespace RocamERP.Models
{
    public class Banco
    {
        public string Nome { get; set; }

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