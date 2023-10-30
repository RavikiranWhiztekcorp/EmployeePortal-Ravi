using Dapper;
using EmployeePortal.DAL.DapperServices;
using EmployeePortal.DAL.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Services.Implementations
{
    public class DapperSPServices<T> : IDapperSPServices<T>
    {
        private string constring = "Server=LAPTOP-46NPMGS0\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;
        public DapperSPServices()
        {
            con = new SqlConnection(constring);
            con.Open();
        }

        public async Task CreateAsync(T entity)
        {
            List<string> prop = new List<string>();
            foreach (var property in entity.GetType().GetProperties())
            {
                prop.Add(property.Name);
            }
            var pro = "";
            for (int i = 0; i < prop.Count; i++)
            {
                if (prop[i]=="Id")
                {
                    pro +="";
                }
                else
                {
                    pro += "@" + prop[i] + ",";
                }
            }
            pro=pro.TrimEnd(',');
            var parameters = new DynamicParameters();
            foreach (var property in entity.GetType().GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(entity));
            }
            var sql = GetInsertStoredProcedureName(entity) +" "+pro;

            await con.ExecuteAsync(sql, parameters);
        }

        //public async Task<T> ReadAsync(T entity)
        //{
        //    var sql = GetSelectStoredProcedureName(entity) + " @Id";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@Id", id);

        //    var result = await con.QueryFirstOrDefaultAsync<T>(sql, parameters);
        //    return result;
        //}
        public async Task<IEnumerable<T>> ReadAllAsync(T entity)
        {
            var sql = GetSelectStoredProcedureName(entity);
            var result = await con.QueryAsync<T>(sql);
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            var sql = GetUpdateStoredProcedureName(entity) + " @Parameters";
            var parameters = new DynamicParameters();
            foreach (var property in entity.GetType().GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(entity));
            }

            await con.ExecuteAsync(sql, parameters);
        }

        //public async Task DeleteAsync(int id)
        //{
        //    var sql = GetDeleteStoredProcedureName(entity) + " @Id";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@Id", id);

        //    await con.ExecuteAsync(sql, parameters);
        //}

        private string GetInsertStoredProcedureName(T entity)
        {
            return $"EXEC sp_Insert{entity.GetType().Name}";
        }

        private string GetSelectStoredProcedureName(T entity)
        {
            return $"sp_Select{entity.GetType().Name}";
        }

        private string GetUpdateStoredProcedureName(T entity)
        {
            return $"sp_Update{entity.GetType().Name}";
        }

        private string GetDeleteStoredProcedureName(T entity)
        {
            return $"sp_Delete{entity.GetType().Name}";
        }
    }
}