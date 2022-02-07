using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleServices _scheduleServices;

        public ScheduleController(IScheduleServices scheduleServices)
        {
            _scheduleServices = scheduleServices;
        }

        [HttpPost]
        [Route("DeleteScheduleById")]
        public void DeleteSchedule(int id)
        {
            _scheduleServices.DeleteSchedule(id);
        }

        [HttpGet]
        [Route("GetAllSchedules")]
        public ActionResult<IEnumerable<ScheduleModel>> GetAllSchedules()
        {
            var schedules = _scheduleServices.GetAllSchedules();
            return Ok(schedules);
        }
    }
}
