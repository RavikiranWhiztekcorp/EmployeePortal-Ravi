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
    }
}
