using AutoMapper;

namespace RocamERP.Presentation.Web.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile(new DomainToViewModelMappingProfile());
                m.AddProfile(new ViewModelToDomainMappingProfile());
                m.AddProfile(new CustomMappingProfile());
            });
        }
    }
}