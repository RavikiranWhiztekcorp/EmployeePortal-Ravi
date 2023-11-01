using Dapper;
using EmployeePortal.Common.Models;
using EmployeePortal.Common.Models.Account;
using EmployeePortal.DAL.Interfaces;
using EmployeePortal.DAL.Services.Implementations;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Implementations
{
    public class EmployeeDALRepo
    {
        private string constring = "Server=WHIZTEK1\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;
        DapperServices<Employee> employeeRepository = new DapperServices<Employee>();

        public EmployeeDALRepo()
        {
            con = new SqlConnection(constring);
        }

       
        public async  Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                var result = await employeeRepository.ReadAllAsync(new Employee() { Id=null});
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public async Task<Employee> GetEmployeeByidAsync(Employee _employee)
        {
            try
            {
                return await employeeRepository.ReadGetByIdAsync(_employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        } 
        public async Task<bool> Create(Employee _employee)
        {
            try
            {

                if (_employee != null)
                {
                    await employeeRepository.CreateAsync(_employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Employee _employee)
        {
            try
            {
                if (_employee != null)
                {
                    await employeeRepository.UpdateAsync(_employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Delete(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    await employeeRepository.DeleteAsync(employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
