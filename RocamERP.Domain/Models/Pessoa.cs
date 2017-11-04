using System.Collections.Generic;

namespace RocamERP.Domain.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
        public virtual CadastroEstadual CadastroEstadual { get; set; }

        public virtual CadastroNacional CadastroNacional { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public Pessoa()
        {
            Enderecos = new List<Endereco>();
            Contatos = new List<Contato>();
            Cheques = new List<Cheque>();
        }
    }
}