using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcesureServices _procesureServices;

        public ProcedureController(IProcesureServices procesureServices)
        {
            _procesureServices = procesureServices;
        }

        [HttpGet]
        [Route("GetAllProcedures")]
        public ActionResult<IEnumerable<ProcedureModel>> GetAllProcedures()
        {
            var procedures = _procesureServices.GetAllProcedures();
            return Ok(procedures);
        }
    }
}
