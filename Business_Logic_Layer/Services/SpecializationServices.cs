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
    public class SpecializationServices : ISpecializationServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public SpecializationServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateSpecialization(SpecializationModel specialization)
        {
            var specializationEntity = GenericAutoMapper<SpecializationModel, Specialization>.Map(specialization);
            _UnitOfWork.Specialization.Add(specializationEntity);
        }

        public void DeleteSpecialization(int id)
        {
            var specializationToDelete = _UnitOfWork.Specialization.GetById(id);
            _UnitOfWork.Specialization.Delete(specializationToDelete);
        }

        public IEnumerable<SpecializationModel> GetAllSpecializations()
        {
            var specializations = _UnitOfWork.Specialization.GetAll();
            IEnumerable<SpecializationModel> specializationModel = GenericAutoMapper<Specialization, SpecializationModel>.MapEnumerable(specializations);
            return specializationModel;
        }

        public SpecializationModel GetSpecializationById(int id)
        {
            var specialization = _UnitOfWork.Specialization.GetById(id);
            SpecializationModel specializationModel = GenericAutoMapper<Specialization, SpecializationModel>.Map(specialization);
            return specializationModel;
        }

        public void UpdateSpecialization()
        {
            throw new NotImplementedException();
        }
    }
}
