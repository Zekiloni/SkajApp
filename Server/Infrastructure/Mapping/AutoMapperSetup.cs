using AutoMapper;

namespace SkajApp.ApiService.Infrastructure.Mapper
{
    public class AutoMapperSetup
    {
        public static IMapper InitializeMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            return configuration.CreateMapper();
        }
    }
}
