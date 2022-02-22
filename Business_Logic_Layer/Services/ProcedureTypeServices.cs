using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class ProcedureTypeServices : IProcedureTypeServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ProcedureTypeServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateProcedureType(ProcedureTypeModel procedureTypeModel)
        {
            ProcedureType procedureTypeEntity = AutoMappers<ProcedureTypeModel, ProcedureType>.Map(procedureTypeModel);
            _UnitOfWork.ProcedureType.Add(procedureTypeEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteProcedureType(int id)
        {
            var procedureTypeToDelete = _UnitOfWork.ProcedureType.GetById(id);
            _UnitOfWork.ProcedureType.Delete(procedureTypeToDelete);
            _UnitOfWork.Complete();
        }

        public ProcedureTypeModel GetProcedureTypeById(int id)
        {
            var procedureType = _UnitOfWork.ProcedureType.GetAll()
                .Include(p => p.Procedures)
                .Include(e => e.Employees)
                .FirstOrDefault(p => p.ProcedureTypeId == id);
            ProcedureTypeModel procedureTypeModel = AutoMappers<ProcedureType, ProcedureTypeModel>.Map(procedureType);
            return procedureTypeModel;
        }

        public IEnumerable<ProcedureTypeModel> GetProcedureTypes()
        {
            var proceduresTypes = _UnitOfWork.ProcedureType.GetAll()
                .Include(p => p.Procedures)
                .Include(e => e.Employees);
            IEnumerable<ProcedureTypeModel> procedureTypeModels = AutoMappers<ProcedureType, ProcedureTypeModel>.MapIQueryable(proceduresTypes);
            return procedureTypeModels;
        }

        public void UpdateProcedureType(ProcedureTypeModel procedureTypeModel)
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }

        public SelectList GetProcedureTypesSelectList(List<ProcedureTypeModel> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var item in list)
            {
                items.Add(new SelectListItem
                {
                    Text = item.ProcedureTypeName,
                    Value = item.ProcedureTypeId.ToString()
                });
            }
            return new SelectList(items, "Value", "Text");
        }
    }
}
