using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class MaterialManufacturerServices : IMaterialManufacturerServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public MaterialManufacturerServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateMaterialManufacturer(MaterialManufacturerModel materialManufacturer)
        {
            MaterialManufacturer materialManufacturerEntity = GenericAutoMapper<MaterialManufacturerModel, MaterialManufacturer>
                .Map(materialManufacturer);
            _UnitOfWork.MaterialManufacturer.Add(materialManufacturerEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteMaterialManufacturer(int id)
        {
            var materialManufacturerToDelete =  _UnitOfWork.MaterialManufacturer.GetById(id);
            _UnitOfWork.MaterialManufacturer.Delete(materialManufacturerToDelete);
            _UnitOfWork.Complete();
        }

        public IEnumerable<MaterialManufacturerModel> GetAllMaterialManufacturers()
        {
            var materialManufacturers =  _UnitOfWork.MaterialManufacturer.GetAll();
            IEnumerable<MaterialManufacturerModel> materialManufacturersModel = GenericAutoMapper<MaterialManufacturer,MaterialManufacturerModel>
                .MapIQueryable(materialManufacturers);
            return materialManufacturersModel;
        }

        public MaterialManufacturerModel GetMaterialManufacturerById(int id)
        {
            var materialManufacturer = _UnitOfWork.MaterialManufacturer.GetById(id);
            MaterialManufacturerModel materialManufacturerModel = GenericAutoMapper<MaterialManufacturer, MaterialManufacturerModel>
                .Map(materialManufacturer);
            return materialManufacturerModel;
        }

        public void UpdateMaterialManufacturer()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }
    }
}
