using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationServices _specializationServices;

        public SpecializationController(ISpecializationServices specializationServices)
        {
            _specializationServices = specializationServices;
        }

        [HttpGet]
        [Route("GetAllSpecializations")]
        public ActionResult<IEnumerable<SpecializationModel>> GetAllSpecializations()
        {
            var specializations = _specializationServices.GetAllSpecializations();
            return Ok(specializations);
        }
    }
}
