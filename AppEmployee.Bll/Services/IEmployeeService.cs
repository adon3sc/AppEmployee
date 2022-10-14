using AppEmployee.Dll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmployee.Bll.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> ListEmployees(string searchString);
        Task AddEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
