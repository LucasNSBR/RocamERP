using System.Collections.Generic;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class Cidade
    {
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string EstadoId { get; set; }
        public Estado Estado { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    
        public Cidade()
        {
            Enderecos = new List<Endereco>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}