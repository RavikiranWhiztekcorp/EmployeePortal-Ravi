using EmployeePortal.Common.Models.Account;
using EmployeePortal.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Interfaces
{
    public class AccountDALRepo:IAccountDALRepo
    {
        private List<User> users = new List<User>
        {
        new User { Username = "user1", Password = "password1" },
        new User { Username = "user2", Password = "password2" }
        };
    

        public bool ValidateUserCredentials(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }
}
