using AutoMapper;
using RocamERP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public abstract class BaseController<TDomain, TViewModel> : Controller 
                                                                where TDomain : class
                                                                where TViewModel : class
    {
        IBaseApplicationService<TDomain> _baseApplicationService;

        public BaseController(IBaseApplicationService<TDomain> baseApplicationService)
        {
            _baseApplicationService = baseApplicationService;
        }

        public List<TDomain> Get()
        {
            try
            {
                var domain = _baseApplicationService.Get();
                var viewmodel = new List<TDomain>();

                foreach (var item in domain)
                {
                   // viewmodel.Add(Mapper.Map<TDomain, TViewModel>(item));
                }

                return viewmodel;
            }
            catch
            {
                throw;
            }
        }
    }
}
