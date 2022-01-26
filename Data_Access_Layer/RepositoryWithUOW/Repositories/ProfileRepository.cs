using Data_Access_Layer.RepositoryWithUOW.Repositories.Interfaces;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.RepositoryWithUOW.Repositories
{
    public class ProfileRepository : GenericRepository<ProFile>, IProfileRepository
    {
        public ProfileRepository(SalonDBContext context) : base(context)
        {
        }
    }
}
