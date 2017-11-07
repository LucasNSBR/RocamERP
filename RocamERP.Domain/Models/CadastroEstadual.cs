namespace RocamERP.Domain.Models
{
    public class CadastroEstadual
    {
        public string NumeroDocumento { get; set; }
        public virtual TipoCadastroEstadual TipoCadastroEstadual { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }

    public enum TipoCadastroEstadual
    {
        RG,
        InscricaoEstadual,
        Isento,
        Outro
    }
}
