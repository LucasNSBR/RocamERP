namespace RocamERP.Models
{
    public class Estado
    {
        public string EstadoId { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}