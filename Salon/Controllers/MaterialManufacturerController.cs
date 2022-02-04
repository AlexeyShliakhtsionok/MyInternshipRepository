using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaterialManufacturerController : ControllerBase
    {
        private readonly IMaterialManufacturerServices _materialManufacturerServices;

        public MaterialManufacturerController(IMaterialManufacturerServices materialManufacturerServices)
        {
            _materialManufacturerServices = materialManufacturerServices;
        }

        [HttpGet]
        [Route("GetAllManufacturers")]
        public ActionResult<IEnumerable<MaterialManufacturerModel>> GetAllManufacturers()
        {
            var manufacrurers = _materialManufacturerServices.GetAllMaterialManufacturers();
            return Ok(manufacrurers);
        }
    }
}
