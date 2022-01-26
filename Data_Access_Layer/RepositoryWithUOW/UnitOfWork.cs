using Data_Access_Layer.RepositoryWithUOW.Repositories;
using Data_Access_Layer.RepositoryWithUOW.Repositories.Interfaces;

namespace Data_Access_Layer.RepositoryWithUOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SalonDBContext _context;
        public IEmployeeRepository Employee { get; private set; }
        public IClientRepository Client { get; private set; }
        public IFeedbackRepository Feedback { get; private set; }
        public IMaterialManufacturerRepository MaterialManufacturer { get; private set; }
        public IMaterialRepository Material { get; private set; }
        public IMediaFileRepository MediaFile { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IProcedureRepository Procedure { get; private set; }
        public IProfileRepository Profile { get; private set; }
        public IScheduleRepository Schedule { get; private set; }
        public ISpecializationRepository Specialization { get; private set; }

        public UnitOfWork(SalonDBContext context)
        {
            _context = context;
            Employee = new EmployeeRepository(context);
            Client = new ClientRepository(context);
            Feedback = new FeedbackRepository(context);
            MaterialManufacturer = new MaterialManufacturerRepository(context);
            Material = new MaterialRepository(context);
            MediaFile = new MediaFileRepository(context);
            Order = new OrderRepository(context);
            Procedure = new ProcedureRepository(context);
            Profile = new ProfileRepository(context);
            Schedule = new ScheduleRepository(context);
            Specialization = new SpecializationRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
