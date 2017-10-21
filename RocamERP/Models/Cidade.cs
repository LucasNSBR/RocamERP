using System.Collections.Generic;

namespace RocamERP.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

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