using System.Collections.Generic;

namespace RocamERP.Domain.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    
        public Cidade()
        {
            Enderecos = new List<Endereco>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}