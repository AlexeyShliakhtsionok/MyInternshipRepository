﻿using AutoMapper;
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
            var employees =  _UnitOfWork.Employee.GetAll().Include(x => x.ProFile);
            IQueryable<EmployeeModel> employeesModel = AutoMappers<Employee, EmployeeModel>.MapIQueryable(employees);
            return employeesModel;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            var employee = _UnitOfWork.Employee.GetAll().Include(e=>e.ProFile).FirstOrDefault(i=>i.EmployeeId ==id);
            EmployeeModel employeeModel = AutoMappers<Employee, EmployeeModel>.Map(employee);
            return employeeModel;
        }

        public void UpdateEmoloyee(EmployeeModel employee)
        {
            var employeeToUpdate = _UnitOfWork.Employee.GetById(employee.EmployeeId);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.PhoneNumber = employee.PhoneNumber;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.Specializations = (Specialization)employee.Specialization;
            employeeToUpdate.Role = ((Role)employee.Role);
            employeeToUpdate.Qualification = (Qualification)employee.Qualification;
            employeeToUpdate.HireDate = employee.HireDate;
 
            _UnitOfWork.Complete();
         }
    }
}
