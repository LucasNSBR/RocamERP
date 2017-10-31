using AutoMapper;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;

namespace RocamERP.Presentation.Web.Mappers.Generic
{
    public class GenericViewModelToDomainMappingProfile<TDomain, TViewModel> : Profile
    {
        public GenericViewModelToDomainMappingProfile()
        {
            CreateMap<TViewModel, TDomain>();
        }
    }
}