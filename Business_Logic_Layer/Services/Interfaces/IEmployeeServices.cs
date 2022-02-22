using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IEmployeeServices
    {
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeById(int id);
        public void CreateEmoloyee(EmployeeModel employee);
        public void UpdateEmoloyee(EmployeeModel employee);
        public void DeleteEmoloyee(int id);
        public IEnumerable<EmployeeModel> GetAllByProcedureType(int id);
    }
}
