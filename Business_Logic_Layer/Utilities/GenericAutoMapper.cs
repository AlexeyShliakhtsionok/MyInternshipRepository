using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Utilities
{
    public static class GenericAutoMapper<TSource, TDestination> 
    {
        private static Mapper _genericMapper = new Mapper(new MapperConfiguration(cfg =>
                   cfg.CreateMap<TSource, TDestination>().ReverseMap()));

        public static TDestination Map(TSource source)
        {
            return _genericMapper.Map<TDestination>(source);
        }

        public static IEnumerable<TDestination> MapEnumerable(IEnumerable<TSource> source)
        {
            var destinationList = new List<TDestination>();
            var sourceList = source.ToList();
            sourceList.ForEach(x => { destinationList.Add(Map(x)); });

            return destinationList.AsEnumerable();
        }
    }
}
