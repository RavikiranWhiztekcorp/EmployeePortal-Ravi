using EmployeePortal.BAL.Interfaces;
using EmployeePortal.Common.Models;
using EmployeePortal.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.BAL.Implementations
{
    public class DepartmentBALRepo : IDepartmentBALRepo
    {
        public DepartmentDALRepo depdalrepo = new DepartmentDALRepo();
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await depdalrepo.GetAllDepartmentsAsync(); 
        }

        public async Task<Department> GetDepartmentByidAsync(Department _department)
        {
            return await depdalrepo.GetDepartmentByidAsync(_department);
        }
        public async Task<bool> Create(Department _department)
        {
            return await depdalrepo.Create(_department);

        }
        public async Task<bool> Update(Department _department)
        {
            return await depdalrepo.Update(_department);

        }
        public async Task<bool> Delete(Department _department)
        {
            return await depdalrepo.Delete(_department);

        }

      
    }
}
