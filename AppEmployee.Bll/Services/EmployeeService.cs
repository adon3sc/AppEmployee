using AppEmployee.Dll.Entities;
using AppEmployee.Dll.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppEmployee.Bll.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> ListEmployees(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var listEmp = await _employeeRepository.GetEmployeesAsync();
                return listEmp.Where(x => x.Emp_LastName.Contains(searchString) || x.Emp_Phone.Contains(searchString)).ToList();
            }
            else
            {
                return await _employeeRepository.GetEmployeesAsync();
            }

        }

        public async Task AddEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeesAsync(employee);
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = new();
            var listEmp = await _employeeRepository.GetEmployeesAsync();
            var emp = listEmp.Where(x => x.Emp_ID == id);
            foreach (var item in emp)
            {
                employee = new Employee
                {
                    Emp_ID = item.Emp_ID,
                    Emp_FirstName = item.Emp_FirstName,
                    Emp_LastName = item.Emp_LastName,
                    Emp_Phone = item.Emp_Phone,
                    Emp_Zip = item.Emp_Zip,
                    Emp_HireDate = item.Emp_HireDate
                };

            }

            return employee;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployeesAsync(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
