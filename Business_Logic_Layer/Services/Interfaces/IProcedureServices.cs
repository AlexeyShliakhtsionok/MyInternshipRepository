using Business_Logic_Layer.Models;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IProcedureServices
    {
        public IEnumerable<ProcedureModel> GetAllProcedures();
        public ProcedureModel GetProcedureById(int id);
        public void CreateProcedure(ProcedureModel procedure);
        public void UpdateProcedure(ProcedureModel procedure);
        public void DeleteProcedure(int id);
        public IEnumerable<ProcedureModel> GetAllProceduresByType(int id);
    }
}
