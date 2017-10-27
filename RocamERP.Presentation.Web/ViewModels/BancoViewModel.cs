using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class BancoViewModel
    {
        [Key]
        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }

        public BancoViewModel()
        {
            Cheques = new List<Cheque>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}