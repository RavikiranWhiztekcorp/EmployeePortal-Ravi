using Dapper;
using EmployeePortal.Common.Models.Account;
using EmployeePortal.DAL.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Services.Implementations
{
    public class DapperServices : IDapperServices<User>
    {
        private string constring = "Server=LAPTOP-46NPMGS0\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;
        public DapperServices()
        {
            con = new SqlConnection(constring);
            con.Open();
        }

        public async Task CreateAsync(User _user)
        {
            var sql = "EXEC SP_Account 'Insert',@Id, @Username,@Email, @Password,@Role, @CreatedDate, @UpdatedDate";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", _user.Id, DbType.Int32);
            parameters.Add("@Username", _user.Username, DbType.String);
            parameters.Add("@Email", _user.Email, DbType.String);
            parameters.Add("@Password", _user.Password, DbType.String);
            parameters.Add("@Role", _user.Role, DbType.String);
            parameters.Add("@CreatedDate", _user.CreatedDate, DbType.DateTime);
            parameters.Add("@UpdatedDate", _user.UpdatedDate, DbType.DateTime);

            await con.ExecuteAsync(sql, parameters);
        }
        public async Task<IEnumerable<User>> ReadAllAsync()
        {
            int id = 0;
            var sql = "EXEC SP_Account 'Select' ";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);
            parameters.Add("@Username", "", DbType.String);
            parameters.Add("@Email", "", DbType.String);
            parameters.Add("@Password", "", DbType.String);
            parameters.Add("@Role", "", DbType.String);
            parameters.Add("@CreatedDate", DateTime.Now, DbType.DateTime);
            parameters.Add("@UpdatedDate", DateTime.Now, DbType.DateTime);
            var users = await con.QueryAsync<User>(sql,parameters);
            return users;
        }
        //public async Task<User> ReadAsync(int id)
        //{
        //    var sql = "EXEC SP_Account 'Select',@Id, @Username,@Email, @Password,@Role, @CreatedDate, @UpdatedDate";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@Id",id, DbType.Int32);
        //    parameters.Add("@Username", "", DbType.String);
        //    parameters.Add("@Email", "", DbType.String);
        //    parameters.Add("@Password", "", DbType.String);
        //    parameters.Add("@Role", "", DbType.String);
        //    parameters.Add("@CreatedDate", "", DbType.DateTime);
        //    parameters.Add("@UpdatedDate", "", DbType.DateTime);

        //    var User = await con.QueryFirstOrDefaultAsync<User>(sql, parameters);
        //    return User;
        //}

        //public async Task UpdateAsync(User _user)
        //{
        //    var sql = "EXEC SP_Account 'Update',@Id, @Username,@Email, @Password,@Role, @CreatedDate, @UpdatedDate";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@Id", _user.Id, DbType.Int32);
        //    parameters.Add("@Username", _user.Username, DbType.String);
        //    parameters.Add("@Email", _user.Email, DbType.String);
        //    parameters.Add("@Password", _user.Password, DbType.String);
        //    parameters.Add("@Role", _user.Role, DbType.String);
        //    parameters.Add("@CreatedDate", _user.CreatedDate, DbType.DateTime);
        //    parameters.Add("@UpdatedDate", _user.UpdatedDate, DbType.DateTime);


        //    await con.ExecuteAsync(sql, parameters);
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var sql = "EXEC SP_Account 'Delete',@Id, @Username,@Email, @Password,@Role, @CreatedDate, @UpdatedDate";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@Id", id, DbType.Int32);
        //    parameters.Add("@Username", "", DbType.String);
        //    parameters.Add("@Email", "", DbType.String);
        //    parameters.Add("@Password", "", DbType.String);
        //    parameters.Add("@Role", "", DbType.String);
        //    parameters.Add("@CreatedDate", "", DbType.DateTime);
        //    parameters.Add("@UpdatedDate", "", DbType.DateTime);

        //    await con.ExecuteAsync(sql, parameters);
        //}
    }
}
