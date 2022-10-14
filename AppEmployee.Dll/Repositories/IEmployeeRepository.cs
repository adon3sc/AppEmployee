using AppEmployee.Dll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmployee.Dll.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task AddEmployeesAsync(Employee employee);
        Task UpdateEmployeesAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
