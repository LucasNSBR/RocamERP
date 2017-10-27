using System.Collections.Generic;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class Estado
    {
        public string Nome { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }

        public Estado()
        {
            Cidades = new List<Cidade>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}