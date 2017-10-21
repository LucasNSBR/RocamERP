using System.Collections.Generic;

namespace RocamERP.Models
{
    public abstract class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Cheques> Cheques { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public Cliente()
        {
            Enderecos = new List<Endereco>();
            Contatos = new List<Contato>();
            Cheques = new List<Cheques>();
        }
    }
}