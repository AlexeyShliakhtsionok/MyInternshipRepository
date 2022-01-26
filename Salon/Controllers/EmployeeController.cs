using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public ActionResult<EmployeeModel> GetEmployeeById(int id)
        {
            var employee = _employeeServices.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("InvalidId");
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public ActionResult<IEnumerable<EmployeeModel>> GetEmployees()
        {
            var employees = _employeeServices.GetAllEmployees();
            return Ok(employees);
            
        }


        //[HttpGet (Name ="GetEmployeesBySpecialization")]
        //public ActionResult<IEnumerable<Employee>> getEmployyeBySpecialization(int id)
        //{
        //    return _employeeServices.GetEmployeesBySpecialization(id);
        //}
    }
}
