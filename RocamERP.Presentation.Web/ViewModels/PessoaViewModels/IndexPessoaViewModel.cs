using System.Collections.Generic;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels.PessoaViewModels
{
    public class IndexPessoaViewModel
    {
        public IEnumerable<PessoaViewModel> Pessoas { get; set; }
        public IEnumerable<SelectListItem> CidadesList { get; set; }
    }
}