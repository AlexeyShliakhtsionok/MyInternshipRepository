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
    public class ProcedureServices : IProcedureServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ProcedureServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateProcedure(ProcedureModel procedure)
        {
            Procedure procedureEntity = AutoMappers<ProcedureModel, Procedure>.Map(procedure);
            procedureEntity.ProcedureType = _UnitOfWork.ProcedureType.GetById(procedure.ProcedureType.ProcedureTypeId);
            List<Material> materials = new List<Material>();
            foreach (var item in procedure.Materials)
            {
                materials.Add(_UnitOfWork.Material.GetById(item.MaterialId));
            }
            procedureEntity.Materials = materials;
            _UnitOfWork.Procedure.Add(procedureEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteProcedure(int id)
        {
            var procedureToDelete = _UnitOfWork.Procedure.GetById(id);
            _UnitOfWork.Procedure.Delete(procedureToDelete);
            _UnitOfWork.Complete();
        }

        public ProcedureModel GetProcedureById(int id)
        {
            var procedure = _UnitOfWork.Procedure.GetAll()
                .Include(m => m.Materials)
                .Include(t => t.ProcedureType)
                .FirstOrDefault(p => p.ProcedureId == id);
            ProcedureModel procedureModel = AutoMappers<Procedure, ProcedureModel>.Map(procedure);
            return procedureModel;
        }

        public IEnumerable<ProcedureModel> GetAllProcedures()
        {
            var procedures = _UnitOfWork.Procedure.GetAll()
                .Include(p => p.ProcedureType)
                .Include(m => m.Materials);
            IEnumerable<ProcedureModel> procedureModels = AutoMappers<Procedure, ProcedureModel>.MapIQueryable(procedures);
            return procedureModels;
        }

        public void UpdateProcedure(ProcedureModel procedure)
        {
            Procedure procedureEntity = AutoMappers<ProcedureModel, Procedure>.Map(procedure);
            List<Material> materials = new List<Material>();

            foreach (var item in procedure.Materials)
            {
                materials.Add(_UnitOfWork.Material.GetById(item.MaterialId));
            }
            procedureEntity.Materials = materials;
            procedureEntity.ProcedureType = _UnitOfWork.ProcedureType.GetById(procedure.ProcedureType.ProcedureTypeId);

            _UnitOfWork.Procedure.Update(procedureEntity);
            _UnitOfWork.Complete();
        }

        public IEnumerable<ProcedureModel> GetAllProceduresByType(int id)
        {
            var procedures = _UnitOfWork.Procedure.GetAll()
                .Include(p => p.ProcedureType)
                .Include(m => m.Materials).Where(i => i.ProcedureType.ProcedureTypeId == id);
            IEnumerable<ProcedureModel> procedureModels = AutoMappers<Procedure, ProcedureModel>.MapIQueryable(procedures);
            return procedureModels;
        }
    }
}
