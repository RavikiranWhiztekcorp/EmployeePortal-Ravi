﻿using EmployeePortal.Common.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.BAL.Interfaces
{
    public interface IAccountBALRepo
    {
        bool ValidateUserCredentials(string username, string password);
        Task<IEnumerable<User>> GetAllAsync();
        Task<bool> Create(User _user);
        Task<bool> UserValidateUserCredentials(User user);

    }
}