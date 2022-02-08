using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class ScheduleServices : IScheduleServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ScheduleServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateSchedule(ScheduleModel schedule)
        {
            Schedule scheduleEntity = AutoMappers<ScheduleModel, Schedule>.Map(schedule);
            _UnitOfWork.Schedule.Add(scheduleEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteSchedule(int id)
        {
            var scheduleToDelete = _UnitOfWork.Schedule.GetById(id);
            _UnitOfWork.Schedule.Delete(scheduleToDelete);
            _UnitOfWork.Complete();
        }

        public ScheduleModel GetScheduleById(int id)
        {
            var schedule = _UnitOfWork.Schedule.GetById(id);
            ScheduleModel scheduleModel = AutoMappers<Schedule, ScheduleModel>.Map(schedule);
            return scheduleModel;
        }

        public IEnumerable<ScheduleModel> GetAllSchedules()
        {
            var schedules = _UnitOfWork.Schedule.GetAll();
            IEnumerable<ScheduleModel> scheduleModels = AutoMappers<Schedule, ScheduleModel>.MapIQueryable(schedules);
            return scheduleModels;
        }

        public void UpdateSchedule()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }
    }
}
