using AutoMapper;

namespace Mastermind.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            { 
                cfg.AddProfile<DomainToModelMappingProfile>();    
                cfg.AddProfile<ModelToDomainMappingProfile>();
            });

            return config.CreateMapper();
        }
    }
}