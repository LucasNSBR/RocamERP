using System;
using System.Collections.Generic;
using System.Linq;

namespace RocamERP.Presentation.Web.ViewModels.CidadeViewModels
{
    public class DetailsCidadeViewModel
    {
        public CidadeViewModel CidadeViewModel { get; set; }
        public IEnumerable<IGrouping<KeyValuePair<int, string>, EnderecoViewModel>> Enderecos { get; set; }
    }
}