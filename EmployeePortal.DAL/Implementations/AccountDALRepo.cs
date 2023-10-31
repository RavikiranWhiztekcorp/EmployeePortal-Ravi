using Dapper;
using EmployeePortal.Common.Models.Account;
using EmployeePortal.DAL.Interfaces;
using EmployeePortal.DAL.Services.Implementations;
using EmployeePortal.DAL.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Implementations
{
    public class AccountDALRepo:IAccountDALRepo
    {
        private string constring = "Server=LAPTOP-46NPMGS0\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;
        DapperServices<User> userRepository = new DapperServices<User>();

        public AccountDALRepo(){
            con = new SqlConnection(constring);
        }

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
       
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            #region sql query

            //var query = "SELECT * FROM Account_tbl";
            ////var query = "SELECT * FROM " + typeof(User).Name;
            //using (con)
            //{
            //    var result = await con.QueryAsync<User>(query);
            //    return result.ToList();
            //}
            //DapperServices dapperService = new DapperServices();
            //var result = await dapperService.ReadAllAsync();
            //return result;
            #endregion

            var result = await userRepository.ReadAllAsync(new User());
            return result;
        }
        public async Task<User> GetByIdAsync(User user)
        {
             return await userRepository.ReadGetByIdAsync(user);
        }
        public async Task<bool> UserValidateUserCredentials(User user)
        {
            var data = await GetByUserNameAsync(user.Username,user.Password);
            return data != null;
        }
        public async Task<User> GetByUserNameAsync(string username,string password)
        {

            #region sql qerey
            var query = "SELECT * FROM Account_tbl WHERE Username = @Username AND Password=@password";
            {
                var result = await con.QuerySingleOrDefaultAsync<User>(query, new { username, password });
                return result;
            }
            #endregion
        }
        public async Task<bool> Create(User _user)
        {
            #region sql qerey
            //var query = "INSERT INTO Account_tbl (Username,Email, Password,Role, CreatedDate,UpdatedDate) VALUES (@Username,@Email, @Password,@Role, @CreatedDate, @UpdatedDate)";
            //var parameters = new DynamicParameters();
            //parameters.Add("Username", _user.Username, DbType.String);
            //parameters.Add("Email", _user.Email, DbType.String);
            //parameters.Add("Password", _user.Password, DbType.String);
            //parameters.Add("Role", _user.Role, DbType.String);
            //parameters.Add("CreatedDate", _user.CreatedDate, DbType.DateTime);
            //parameters.Add("UpdatedDate", _user.UpdatedDate, DbType.DateTime);
            //using (con)
            //{
            //    await con.ExecuteAsync(query, parameters);
            //    return true;
            //}
            //return false;
            #endregion

            if (_user!=null)
            {
                await userRepository.CreateAsync(_user);
                return true;
            }
            return false;

        }
        public async Task<bool> Update(User _user)
        {
            if (_user != null)
            {
                await userRepository.UpdateAsync(_user);
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(User _user)
        {
            if (_user != null)
            {
                await userRepository.DeleteAsync(_user);
                return true;
            }
            return false;
        }
    }
}
