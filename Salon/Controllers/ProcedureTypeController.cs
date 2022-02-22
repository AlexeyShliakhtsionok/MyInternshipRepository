using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProcedureTypeController : ControllerBase
    {
        private readonly IProcedureTypeServices _procedureTypeServices;

        public ProcedureTypeController(IProcedureTypeServices procedureTypeServices)
        {
            _procedureTypeServices = procedureTypeServices;
        }

        [HttpPost]
        [Route("DeleteProcedureTypeById")]
        public void DeleteProcedure(int id)
        {
            _procedureTypeServices.DeleteProcedureType(id);
        }

        [HttpGet]
        [Route("GetAllProcedureTypes")]
        public ActionResult<IEnumerable<ProcedureTypeModel>> GetAllProcedureTypes()
        {
            var procedures = _procedureTypeServices.GetProcedureTypes();
            return Ok(procedures);
        }
    }
}

