using Data_Access_Layer.RepositoryWithUOW.Repositories.Interfaces;

namespace Data_Access_Layer.RepositoryWithUOW
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        IClientRepository Client { get; }
        IFeedbackRepository Feedback { get; }
        IMaterialRepository Material { get; }
        IMaterialManufacturerRepository MaterialManufacturer { get; }
        IMediaFileRepository MediaFile { get; }
        IOrderRepository Order { get; }
        IProcedureRepository Procedure { get; }
        IProcedureTypeRepository ProcedureType { get; }

        void Complete();
        void Dispose();
    }
}
