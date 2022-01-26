using Data_Access_Layer.RepositoryWithUOW.Repositories.Interfaces;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.RepositoryWithUOW.Repositories
{
    public class SpecializationRepository : GenericRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(SalonDBContext context) : base(context)
        {
        }
    }
}
