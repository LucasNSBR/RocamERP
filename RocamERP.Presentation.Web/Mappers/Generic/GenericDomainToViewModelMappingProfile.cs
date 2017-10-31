using AutoMapper;

namespace RocamERP.Presentation.Web.Mappers.Generic
{
    public class GenericDomainToViewModelMappingProfile<TDomain, TViewModel> : Profile
    {
        public GenericDomainToViewModelMappingProfile()
        {
            CreateMap<TDomain, TViewModel>();
        }
    }
}