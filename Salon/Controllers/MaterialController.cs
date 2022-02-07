using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialServices _materialServices;

        public MaterialController(IMaterialServices materialServices)
        {
            _materialServices = materialServices;
        }

        [HttpPost]
        [Route("DeleteMaterialById")]
        public void DeleteMaterial(int id)
        {
            _materialServices.DeleteMaterial(id);
        }

        [HttpGet]
        [Route("GetAllMaterials")]
        public ActionResult<IEnumerable<MaterialModel>> GetMaterials()
        {
            var materials = _materialServices.GetAllMaterials();
            return Ok(materials);
        }
    }
}
