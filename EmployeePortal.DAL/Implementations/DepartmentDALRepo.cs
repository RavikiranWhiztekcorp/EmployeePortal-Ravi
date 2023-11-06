using EmployeePortal.Common.Models;
using EmployeePortal.DAL.Interfaces;
using EmployeePortal.DAL.Services.Implementations;
using Microsoft.Data.SqlClient;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Implementations
{
    public class DepartmentDALRepo : IDepartmentDALRepo<T>
    {
        private string constring = "Server=LAPTOP-AD2EEPGA\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        
        private SqlConnection con;
       
        DapperServices<Department> departmentRepository = new DapperServices<Department>();

        public DepartmentDALRepo()
        {
            con = new SqlConnection(constring);
        }

      
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                var result = await departmentRepository.ReadAllAsync(new Department() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Department> GetDepartmentByidAsync(Department _department)
        {
            try
            {
                return await departmentRepository.ReadGetByIdAsync(_department);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Create(Department _department)
        {
            try
            {

                if (_department != null)
                {
                    await departmentRepository.CreateAsync(_department);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Department _department)
        {
            try
            {
                if (_department != null)
                {
                    await departmentRepository.UpdateAsync(_department);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Delete(Department _department)
        {
            try
            {
                if (_department != null)
                {
                    await departmentRepository.DeleteAsync(_department);
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
