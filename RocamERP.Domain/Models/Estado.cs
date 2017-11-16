using System.Collections.Generic;

namespace RocamERP.Domain.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }

        public Estado()
        {
            Cidades = new List<Cidade>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}