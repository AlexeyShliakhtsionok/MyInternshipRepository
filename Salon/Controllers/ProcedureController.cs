using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureServices _procesureServices;
        private readonly IMaterialServices _materialServices;
        private readonly IProcedureTypeServices _procedureTypeServices;

        public ProcedureController(IProcedureTypeServices procedureTypeServices, IProcedureServices procesureServices, IMaterialServices materialServices)
        {
            _procesureServices = procesureServices;
            _materialServices = materialServices;
            _procedureTypeServices = procedureTypeServices;
        }

        [HttpPost]
        [Route("DeleteServiceById")]
        public void DeleteProcedure(int id)
        {
            _procesureServices.DeleteProcedure(id);
        }

        [HttpPost, Route("CreateProcedure")]
        public void CreateProcedure([FromBody] ProcedureModel procedure)
        {
            _procesureServices.CreateProcedure(procedure);
        }

        [HttpGet]
        [Route("GetAllProcedures")]
        public ActionResult<IEnumerable<ProcedureModel>> GetAllProcedures()
        {
            var procedures = _procesureServices.GetAllProcedures();
            var procedureTypesList = _procedureTypeServices.GetProcedureTypesSelectList(_procedureTypeServices.GetProcedureTypes().ToList());
            var materialsList = _materialServices.GetMaterialsSelectList(_materialServices.GetAllMaterials().ToList());
            var procedureTypes = _procedureTypeServices.GetProcedureTypes();
            var materials = _materialServices.GetAllMaterials();
            return Ok(new { procedures, procedureTypesList, materialsList, procedureTypes, materials});
        }

        [HttpGet]
        [Route("GetAllProceduresByType")]
        public ActionResult<IEnumerable<ProcedureModel>> GetAllProceduresByType(int id)
        {
            var procedures = _procesureServices.GetAllProceduresByType(id);
            return Ok(procedures);
        }

        [HttpGet]
        [Route("GetServiceById")]
        public ActionResult<ProcedureModel> GetServiceById(int id)
        {
            var procedure = _procesureServices.GetProcedureById( id);
            if (procedure == null)
            {
                return NotFound("InvalidId");
            }
            return Ok(procedure);
        }

        [HttpPost, Route("UpdateService")]
        public void UpdateService([FromBody]ProcedureModel service)
        {
            _procesureServices.UpdateProcedure(service);
        }
    }
}
