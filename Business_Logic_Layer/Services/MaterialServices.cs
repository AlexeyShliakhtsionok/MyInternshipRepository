using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Material materialEntity = GenericAutoMapper<MaterialModel, Material>.Map(material);
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
            var materials = _UnitOfWork.Material.GetAll().Include(m => m.MaterialManufacturer);
            IEnumerable<MaterialModel> materialModels = GenericAutoMapper<Material, MaterialModel>.MapIQueryable(materials);
            return materialModels;
        }

        public MaterialModel GetMaterialById(int id)
        {
            var materialEntity = _UnitOfWork.Material.GetById(id);
            MaterialModel materialModel = GenericAutoMapper<Material, MaterialModel>.Map(materialEntity);
            return materialModel;
        }

        public void UpdateMaterial()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }
    }
}
