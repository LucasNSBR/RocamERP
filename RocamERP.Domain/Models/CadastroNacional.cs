namespace RocamERP.Domain.Models
{
    public class CadastroNacional
    {
        public string NumeroDocumento { get; set; }
        public virtual TipoCadastroNacional TipoCadastroNacional { get; set; }

        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        
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
