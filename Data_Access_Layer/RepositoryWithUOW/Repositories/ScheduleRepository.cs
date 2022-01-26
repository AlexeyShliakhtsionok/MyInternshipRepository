using Data_Access_Layer.RepositoryWithUOW.Repositories.Interfaces;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.RepositoryWithUOW.Repositories
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(SalonDBContext context) : base(context)
        {
        }
    }
}
