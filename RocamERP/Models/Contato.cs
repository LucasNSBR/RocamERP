namespace RocamERP.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Observacao { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public TipoContato TipoContato { get; set; }

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