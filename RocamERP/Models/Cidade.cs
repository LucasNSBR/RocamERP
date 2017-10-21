namespace RocamERP.Models
{
    public class Cidade
    {
        public string Nome { get; set; }
        public string CEP { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}