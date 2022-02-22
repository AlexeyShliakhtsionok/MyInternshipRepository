using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IProcedureTypeServices
    {
        public IEnumerable<ProcedureTypeModel> GetProcedureTypes();
        public ProcedureTypeModel GetProcedureTypeById(int id);
        public void CreateProcedureType(ProcedureTypeModel procedureType);
        public void UpdateProcedureType(ProcedureTypeModel procedureType);
        public void DeleteProcedureType(int id);
        public SelectList GetProcedureTypesSelectList(List<ProcedureTypeModel> list);
    }
}
