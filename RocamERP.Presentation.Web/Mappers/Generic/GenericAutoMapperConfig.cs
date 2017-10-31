using AutoMapper;

namespace RocamERP.Presentation.Web.Mappers.Generic
{
    public class GenericAutoMapperConfig<TDomain, TViewModel>
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile(new DomainToViewModelMappingProfile());
                m.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}