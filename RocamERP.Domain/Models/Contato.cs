namespace RocamERP.Domain.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Observacao { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

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