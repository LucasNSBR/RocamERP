namespace RocamERP.Domain.Models
{
    public class CadastroNacional
    {
        public string NumeroDocumento { get; set; }
        public TipoCadastroNacional TipoCadastroNacional { get; set; }        
        public override string ToString()
        {
            return NumeroDocumento;
        }
    }

    public enum TipoCadastroNacional
    {
        CPF,
        CNPJ,
        Isento,
        Outro,
    }
}
