using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.DapperServices
{
    public class DapperContext
    {
        public IDbConnection CreateConnection()
            => new SqlConnection("Server=LAPTOP-46NPMGS0\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
    }
}
