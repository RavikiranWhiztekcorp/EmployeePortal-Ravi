using EmployeePortal.Common.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Interfaces
{
    public interface IAccountDALRepo
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(User user);
        Task<bool> Create(User _user);
        Task<bool> Update(User _user);
        Task<bool> Delete(User _user);
        Task<bool> UserValidateUserCredentials(User user);
        Task<User> GetByUserNameAsync(string username,string password);
        //bool ValidateUserCredentials(string username, string password);
    }
}
