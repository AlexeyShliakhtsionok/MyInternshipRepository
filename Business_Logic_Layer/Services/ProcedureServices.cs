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
            Procedure procedureEntity = GenericAutoMapper<ProcedureModel, Procedure>.Map(procedure);
            _UnitOfWork.Procedure.Add(procedureEntity);
        }

        public void DeleteProcedure(int id)
        {
            var procedureToDelete = _UnitOfWork.Procedure.GetById(id);
            _UnitOfWork.Procedure.Delete(procedureToDelete);
        }

        public ProcedureModel GetProcedureById(int id)
        {
            var procedure = _UnitOfWork.Procedure.GetById(id);
            ProcedureModel procedureModel = GenericAutoMapper<Procedure, ProcedureModel>.Map(procedure);
            return procedureModel;
        }

        public IEnumerable<ProcedureModel> GetAllProcedures()
        {
            var procedures = _UnitOfWork.Procedure.GetAll();
            IEnumerable<ProcedureModel> procedureModels = GenericAutoMapper<Procedure, ProcedureModel>.MapEnumerable(procedures);
            return procedureModels;
        }

        public void UpdateProcedure()
        {
            throw new NotImplementedException();
        }
    }
}
