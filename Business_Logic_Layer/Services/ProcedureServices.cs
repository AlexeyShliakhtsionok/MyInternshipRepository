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
    public class ProcedureServices : IProcesureServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ProcedureServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateProcedure(ProcedureModel procedure)
        {
            Procedure procedureEntity = AutoMappers<ProcedureModel, Procedure>.Map(procedure);
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
            var procedure = _UnitOfWork.Procedure.GetById(id);
            ProcedureModel procedureModel = AutoMappers<Procedure, ProcedureModel>.Map(procedure);
            return procedureModel;
        }

        public IEnumerable<ProcedureModel> GetAllProcedures()
        {
            var procedures = _UnitOfWork.Procedure.GetAll();
            IEnumerable<ProcedureModel> procedureModels = AutoMappers<Procedure, ProcedureModel>.MapIQueryable(procedures);
            return procedureModels;
        }

        public void UpdateProcedure()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }
    }
}
