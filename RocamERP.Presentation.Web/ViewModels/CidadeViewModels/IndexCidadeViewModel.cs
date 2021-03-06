﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels.CidadeViewModels
{
    public class IndexCidadeViewModel
    {
        public IEnumerable<CidadeViewModel> Cidades { get; set; }
        public IEnumerable<SelectListItem> EstadosList { get; set; }
    }
}