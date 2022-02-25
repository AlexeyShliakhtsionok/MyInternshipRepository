using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Business_Logic_Layer.Utilities;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialServices _materialServices;
        private readonly IMaterialManufacturerServices _materialManufacturerServices;
        public MaterialController(IMaterialServices materialServices, IMaterialManufacturerServices materialManufacturerServices)
        {
            _materialManufacturerServices = materialManufacturerServices;
            _materialServices = materialServices;
        }

        [HttpPost]
        [Route("CreateMaterial")]
        public void CreateMaterial([FromBody] MaterialModel materialInput)
        {
            _materialServices.CreateMaterial(materialInput);
        }

        [HttpPost]
        [Route("DeleteMaterialById")]
        public void DeleteMaterial(int id)
        {
            _materialServices.DeleteMaterial(id);
        }

        [HttpPost]
        [Route("UpdateMaterial")]
        public void UpdateMaterial([FromBody] MaterialModel materialInput)
        {
            _materialServices.UpdateMaterial(materialInput);
        }

        [HttpGet]
        [Route("GetMaterialById")]
        public ActionResult<MaterialModel> GetMaterialById(int id)
        {
            var material = _materialServices.GetMaterialById(id);
            if (material == null)
            {
                return NotFound("InvalidId");
            }

            return Ok(material);
        }

        //[HttpGet]
        //[Route("GetAllMaterials")]
        //public ActionResult<IEnumerable<MaterialModel>> GetMaterials()
        //{
        //    var manufacturers = _materialManufacturerServices.GetAllMaterialManufacturers().ToList();
        //    var manufacturerSelectList = _materialManufacturerServices.GetManufacturersSelectList(manufacturers);
        //    var materials = _materialServices.GetAllMaterials();

        //    return Ok(new { materials, manufacturers, manufacturerSelectList });
        //}

        [HttpGet]
        [Route("GetAllMaterials")]
        public ActionResult<IEnumerable<MaterialModel>> GetMaterials(int elementsPerPage)
        {
            var manufacturers = _materialManufacturerServices.GetAllMaterialManufacturers().ToList();
            var manufacturerSelectList = _materialManufacturerServices.GetManufacturersSelectList(manufacturers);
            var materials = _materialServices.GetAllMaterials().ToList();
            double pages = (double)materials.Count() / elementsPerPage;
            pages = Math.Ceiling(pages);


            List<MaterialModel>[] pagedMaterials = new List<MaterialModel>[(int)pages];
            for (int j = 0; j < pagedMaterials.Length; j++)
            {
                pagedMaterials[j] = new List<MaterialModel>();
            }

            for (int i = 0; i < pagedMaterials.Length; i++)
            {
                for (int j = 0; j < materials.Count(); j++)
                {
                    if (j != 0 && j % elementsPerPage == 0)
                    {
                        i++;
                    };
                    pagedMaterials[i].Add(materials[j]);
                }
            }


            return Ok(new { materials, pagedMaterials, manufacturers, manufacturerSelectList, pages });
        }
    }
}
