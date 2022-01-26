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
    }
}
