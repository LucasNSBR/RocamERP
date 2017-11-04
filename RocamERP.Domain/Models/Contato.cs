namespace RocamERP.Domain.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Observacao { get; set; }

        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public virtual TipoContato TipoContato { get; set; }

        public override string ToString()
        {
            return Observacao;
        }
    }

    public enum TipoContato
    {
        Residencial,
        Comercial,
        Telefone,
        WhatsApp,
        Email,
    }
}