using AppEmployee.Dll.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmployee.Dll.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly IOptions<AplicationSettings> _settings;

        public EmployeeRepository(IOptions<AplicationSettings> settings)
        {
            _settings = settings;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> listEmp = new();
            string connectionString = _settings.Value.ConectionEmpDB;
            string queryString = "sp_employee_records";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@option", 1);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                try
                {
                    while (reader.Read())
                    {
                        listEmp.Add(new Employee()
                        {
                            Emp_ID = (int)reader["Emp_ID"],
                            Emp_FirstName = (string)reader["Emp_FirstName"],
                            Emp_LastName = (string)reader["Emp_LastName"],
                            Emp_Phone = (string)reader["Emp_Phone"],
                            Emp_Zip = (string)reader["Emp_Zip"],
                            Emp_HireDate = (DateTime)reader["Emp_HireDate"]
                        });
                    }
                }
                finally
                {
                    reader.Close();
                }

                return listEmp;
            }
        }

        public async Task AddEmployeesAsync(Employee employee)
        {
            string connectionString = _settings.Value.ConectionEmpDB;
            string queryString = "sp_employee_records";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@option", 2);
                command.Parameters.AddWithValue("@emp_LastName", employee.Emp_LastName);
                command.Parameters.AddWithValue("@emp_FirstName", employee.Emp_FirstName);
                command.Parameters.AddWithValue("@emp_Phone", employee.Emp_Phone);
                command.Parameters.AddWithValue("@emp_Zip", employee.Emp_Zip);
                command.Parameters.AddWithValue("@emp_HireDate", employee.Emp_HireDate);
                connection.Open();
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch { }
            }
        }

        public async Task UpdateEmployeesAsync(Employee employee)
        {
            string connectionString = _settings.Value.ConectionEmpDB;
            string queryString = "sp_employee_records";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@option", 3);
                command.Parameters.AddWithValue("@emp_ID", employee.Emp_ID);
                command.Parameters.AddWithValue("@emp_LastName", employee.Emp_LastName);
                command.Parameters.AddWithValue("@emp_FirstName", employee.Emp_FirstName);
                command.Parameters.AddWithValue("@emp_Phone", employee.Emp_Phone);
                command.Parameters.AddWithValue("@emp_Zip", employee.Emp_Zip);
                command.Parameters.AddWithValue("@emp_HireDate", employee.Emp_HireDate);
                connection.Open();
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch { }
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            List<Employee> listEmp = new();
            string connectionString = _settings.Value.ConectionEmpDB;
            string queryString = "sp_employee_records";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@option", 4);
                command.Parameters.AddWithValue("@emp_id", id);
                connection.Open();
                try
                {
                   await command.ExecuteNonQueryAsync();
                }
                catch
                {

                }
            }
        }
    }
}
