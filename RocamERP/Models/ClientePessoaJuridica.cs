namespace RocamERP.Models
{
    public class ClientePessoaJuridica : Cliente
    {
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
    }
}