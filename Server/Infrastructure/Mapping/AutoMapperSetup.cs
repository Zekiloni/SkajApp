using AutoMapper;
using Server.Infrastructure.Mapper;

namespace Server.Infrastructure.Mapper
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
