using AutoMapper;

namespace Mastermind.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            //var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(typeof(TSource)) && x.DestinationType.Equals(typeof(TDestination)));

            foreach (var property in expression.TypeMap.GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.Ignore());
            }

            return expression;
        }
    }
}
