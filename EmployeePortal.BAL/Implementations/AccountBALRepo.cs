using EmployeePortal.BAL.Interfaces;
using EmployeePortal.Common.Models.Account;
using EmployeePortal.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.BAL.Implementations
{
    public class AccountBALRepo : IAccountBALRepo
    {
        private AccountDALRepo _accountDALRepo;
        public AccountBALRepo()
        {
            _accountDALRepo = new AccountDALRepo();
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _accountDALRepo.GetAllAsync();
        }
        public async Task<User> GetByIdAsync(User user)
        {
            return await _accountDALRepo.GetByIdAsync(user);
        }
        public async Task<bool> Create(User _user)
        {
            return await _accountDALRepo.Create(_user);
        }
        public async Task<bool> Update(User _user)
        {
            return await _accountDALRepo.Update(_user);
        }
        public async Task<bool> Delete(User _user)
        {
            return await _accountDALRepo.Delete(_user);
        }
        //public bool ValidateUserCredentials(string username, string password)
        //{
        //    return _accountDALRepo.ValidateUserCredentials(username, password);
        //}
        public async Task<bool> UserValidateUserCredentials(User user)
        {
            return await _accountDALRepo.UserValidateUserCredentials(user);
        }
    }

}
