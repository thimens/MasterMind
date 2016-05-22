using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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