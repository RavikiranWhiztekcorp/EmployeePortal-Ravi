﻿using EmployeePortal.BAL.Interfaces;
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
        //implement DI
        private AccountDALRepo _accountDALRepo = new AccountDALRepo();
        public Task<bool> Create(User _user)
        {
            return _accountDALRepo.Create(_user);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _accountDALRepo.GetAllAsync();
        }

        
        public bool ValidateUserCredentials(string username, string password)
        {
           return _accountDALRepo.ValidateUserCredentials(username, password);
        }
        public async Task<bool> UserValidateUserCredentials(User user)
        {
            return await _accountDALRepo.UserValidateUserCredentials(user);
        }
    }
}
