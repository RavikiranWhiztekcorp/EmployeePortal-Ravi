using EmployeePortal.BAL.Interfaces;
using EmployeePortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.BAL.Implementations
{
    public class AccountBALRepo : IAccountBALRepo
    {
        //implement DI
        private AccountDALRepo _accountDALRepo = new AccountDALRepo();
        public bool ValidateUserCredentials(string username, string password)
        {
           return _accountDALRepo.ValidateUserCredentials(username, password);
        }
    }
}
