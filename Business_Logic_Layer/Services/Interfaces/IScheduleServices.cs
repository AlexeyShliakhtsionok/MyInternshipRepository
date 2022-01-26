using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IScheduleServices
    {
        public IEnumerable<ScheduleModel> GetAllSchedules();
        public ScheduleModel GetScheduleById(int id);
        public void CreateSchedule(ScheduleModel schedule);
        public void UpdateSchedule();
        public void DeleteSchedule(int id);
    }
}
