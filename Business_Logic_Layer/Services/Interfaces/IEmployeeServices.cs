using Business_Logic_Layer.DBO.Employees;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IEmployeeServices
    {
        public IEnumerable<EmployeesAuthenticationModel> GetEmployeesCredentials();
        public IEnumerable<EmployeesInformationViewModel> GetAllEmployees();
        public EmployeeInformationViewModel GetEmployeeById(int id);
        public void CreateEmoloyee(EmployeeViewModel employee);
        public void UpdateEmoloyee(EmployeeInformationViewModel employee);
        public void DeleteEmoloyee(int id);
        public IEnumerable<EmployeeViewModel> GetAllByProcedureType(int id);
        public SelectList GetEmployeesSelectList();
    }
}
