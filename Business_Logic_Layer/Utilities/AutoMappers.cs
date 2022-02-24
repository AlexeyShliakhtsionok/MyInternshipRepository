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

            cfg.CreateMap<EmployeeModel, Employee>()
                .ForMember(dest => dest.ProcedureType, opt => opt
                .Ignore())
                .ForMember(dest => dest.MediaFiles, opt => opt.Ignore());
            cfg.CreateMap<Employee, EmployeeModel>();

            cfg.CreateMap<Order, OrderModel>();
            cfg.CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.Client, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore())
                .ForMember(dest => dest.Procedure, opt => opt.Ignore());

            cfg.CreateMap<ProcedureModel, Procedure>()
                .ForMember(dest => dest.ProcedureType, opt => opt.Ignore())
                .ForMember(dest => dest.Materials, opt => opt.Ignore());
            cfg.CreateMap<Procedure, ProcedureModel>();

            cfg.CreateMap<Feedback, FeedbackModel>();
            cfg.CreateMap<FeedbackModel, Feedback>()
                .ForMember(dest => dest.Client, opt => opt.Ignore());

            cfg.CreateMap<Client, ClientModel>().ReverseMap();

            cfg.CreateMap<ProcedureType, ProcedureTypeModel>().ReverseMap();

            cfg.CreateMap<MaterialManufacturer, MaterialManufacturerModel>().ReverseMap();

            cfg.CreateMap<MediaFile, MediaFileModel>()
                .ForMember(dest => dest.Employee, opt => opt.Ignore());
                cfg.CreateMap<MediaFileModel, MediaFile>();

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

