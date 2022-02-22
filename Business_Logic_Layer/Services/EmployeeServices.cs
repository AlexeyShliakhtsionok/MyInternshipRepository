using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic_Layer.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public EmployeeServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateEmoloyee(EmployeeModel employee)
        {
            Employee employeeEntity = AutoMappers<EmployeeModel, Employee>.Map(employee);
            employeeEntity.ProcedureType = _UnitOfWork.ProcedureType.GetById(employee.ProcedureType.ProcedureTypeId);
            _UnitOfWork.Employee.Add(employeeEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteEmoloyee(int id)
        {
            var employeeToDelete =  _UnitOfWork.Employee.GetById(id);

             _UnitOfWork.Employee.Delete(employeeToDelete);
            _UnitOfWork.Complete();
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            var employees = _UnitOfWork.Employee.GetAll()
                .Include(x => x.ProFile)
                .Include(pt => pt.ProcedureType)
                .Include(o => o.Orders);
           
            IQueryable<EmployeeModel> employeesModel = AutoMappers<Employee, EmployeeModel>.MapIQueryable(employees);
            return employeesModel;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            var employee = _UnitOfWork.Employee.GetAll()
                .Include(e=>e.ProFile)
                .Include(pt => pt.ProcedureType)
                .Include(o => o.Orders)
                .FirstOrDefault(i=>i.EmployeeId ==id);
            EmployeeModel employeeModel = AutoMappers<Employee, EmployeeModel>.Map(employee);
            return employeeModel;
        }

        public void UpdateEmoloyee(EmployeeModel employee)
        {
            Employee employeeEntity = AutoMappers<EmployeeModel, Employee>.Map(employee);
            employeeEntity.ProcedureType = _UnitOfWork.ProcedureType.GetById(employee.ProcedureType.ProcedureTypeId);
            _UnitOfWork.Employee.Update(employeeEntity);
            _UnitOfWork.Complete();
         }

        public IEnumerable<EmployeeModel> GetAllByProcedureType(int id)
        {
            var employees = _UnitOfWork.Employee.GetAll()
                .Include(x => x.ProFile)
                .Include(pt => pt.ProcedureType)
                .Include(o => o.Orders)
                .Where(pt => pt.ProcedureType.ProcedureTypeId == id);
            IQueryable<EmployeeModel> employeesModel = AutoMappers<Employee, EmployeeModel>.MapIQueryable(employees);
            return employeesModel;
        }
    }
}
