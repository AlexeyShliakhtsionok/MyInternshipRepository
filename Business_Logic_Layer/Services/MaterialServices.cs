using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic_Layer.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public MaterialServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateMaterial(MaterialModel material)
        {
            Material materialEntity = AutoMappers<MaterialModel, Material>.Map(material);
            materialEntity.MaterialManufacturer = _UnitOfWork.MaterialManufacturer
                .GetById(material.MaterialManufacturer.ManufacturerId);
           
            _UnitOfWork.Material.Add(materialEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteMaterial(int id)
        {
            var materialToDelete = _UnitOfWork.Material.GetById(id);
             _UnitOfWork.Material.Delete(materialToDelete);
            _UnitOfWork.Complete();
        }

        public IEnumerable<MaterialModel> GetAllMaterials()
        {
            var materials = _UnitOfWork.Material.GetAll()
                .Include(m => m.MaterialManufacturer)
                .Include(p => p.Procedures);
                
            IEnumerable<MaterialModel> materialModels = AutoMappers<Material, MaterialModel>.MapIQueryable(materials);
            return materialModels;
        }

        public MaterialModel GetMaterialById(int id)
        {
            var materialEntity = _UnitOfWork.Material.GetAll()
                .Include(m => m.MaterialManufacturer)
                .Include(p => p.Procedures)
                .FirstOrDefault(m => m.MaterialId == id);
            MaterialModel materialModel = AutoMappers<Material, MaterialModel>.Map(materialEntity);
            return materialModel;
        }

        public void UpdateMaterial(MaterialModel material)
        {
            Material materialEntity = AutoMappers<MaterialModel, Material>.Map(material);
            materialEntity.MaterialManufacturer = _UnitOfWork.MaterialManufacturer
                .GetById(material.MaterialManufacturer.ManufacturerId);
           
            _UnitOfWork.Material.Update(materialEntity);

            _UnitOfWork.Complete();
        }

        public SelectList GetMaterialsSelectList(List<MaterialModel> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var item in list)
            {
                items.Add(new SelectListItem
                {
                    Text = item.MaterialName,
                    Value = item.MaterialId.ToString()
                });
            }
            return new SelectList(items, "Value", "Text");
        }
    }
}
