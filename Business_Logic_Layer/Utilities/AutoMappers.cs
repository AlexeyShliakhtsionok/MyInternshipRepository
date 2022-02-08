using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Access_Layer;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Utilities
{
    public static class AutoMappers<TSource, TDestination> 
    {
        private static Mapper _autoMapper = new Mapper(new MapperConfiguration(cfg =>
        {
           {
            cfg.CreateMap<MaterialModel, Material>()
                .ForMember(m => m.MaterialManufacturer, opt => opt
                .Ignore());








            cfg.CreateMap<Material, MaterialModel>();
            cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
            cfg.CreateMap<ProFile, ProfileModel>().ReverseMap();
            cfg.CreateMap<Order, OrderModel>().ReverseMap();
            cfg.CreateMap<Schedule, ScheduleModel>().ReverseMap();
            cfg.CreateMap<Client, ClientModel>().ReverseMap();
            cfg.CreateMap<Feedback, FeedbackModel>().ReverseMap();
            cfg.CreateMap<MaterialManufacturer, MaterialManufacturerModel>().ReverseMap();
            cfg.CreateMap<MediaFile, MediaFileModel>().ReverseMap();
            cfg.CreateMap<Procedure, ProcedureModel>().ReverseMap();
           }
     }));

        public static TDestination Map(TSource source)
        {
            return _autoMapper.Map<TDestination>(source);
        }

        public static IQueryable<TDestination> MapIQueryable(IQueryable<TSource> source)
        {
            List<TDestination> destinationList = new List<TDestination>();

            foreach (var item in source)
            {
                destinationList.Add(Map(item));
            }

            return destinationList.AsQueryable<TDestination>();
        }
    }
}

