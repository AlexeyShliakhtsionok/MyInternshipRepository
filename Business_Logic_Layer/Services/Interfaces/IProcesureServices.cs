using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IProcesureServices
    {
        public IEnumerable<ProcedureModel> GetAllProcedures();
        public ProcedureModel GetProcedureById(int id);
        public void CreateProcedure(ProcedureModel procedure);
        public void UpdateProcedure();
        public void DeleteProcedure(int id);
    }
}
