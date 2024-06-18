﻿using Dapper;
using EmployeePortal.Common.Models.Account;
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
    public class DapperServices<T> : IDapperServices<T>
    {
        private string constring = "Server=LAPTOP-AD2EEPGA\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;
        public DapperServices()
        {
            con = new SqlConnection(constring);
            con.Open();
        }
        public async Task<IEnumerable<T>> ReadAllAsync(T entity)
        {
            try
            {
                var sql = GetSelectStoredProcedureName(entity)+ " @Id";
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                };
                var result = await con.QueryAsync<T>(sql,parameters);
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> ReadGetByIdAsync(T entity)
        {
            try
            {
                var sql = GetSelectStoredProcedureName(entity) + " @Id";
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                }
                var result = await con.QueryFirstOrDefaultAsync<T>(sql, parameters);
                con.Close();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task CreateAsync(T entity)
        {
            try
            {
                List<string> prop = new List<string>();
                foreach (var property in entity.GetType().GetProperties())
                {
                    prop.Add(property.Name);
                }
                var pro = "";
                for (int i = 0; i < prop.Count; i++)
                {
                    if (prop[i] == "Id")
                    {
                        pro += "";
                    }
                    else
                    {
                        pro += "@" + prop[i] + ",";
                    }
                }
                pro = pro.TrimEnd(',');
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                }
                var sql = GetInsertStoredProcedureName(entity) + " " + pro;

                await con.ExecuteAsync(sql, parameters);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task UpdateAsync(T entity)
        {

            try
            {
                List<string> prop = new List<string>();
                foreach (var property in entity.GetType().GetProperties())
                {
                    if (property.GetValue(entity) != null)
                    {
                        prop.Add(property.Name != "CreatedDate" ? property.Name : "");
                    }
                }
                var pro = "";
                for (int i = 0; i < prop.Count; i++)
                {
                    if (prop[i] == "")
                    {
                        pro += "";
                    }
                    else
                    {
                        pro += "@" + prop[i] + ",";
                    }
                }
                pro = pro.TrimEnd(',');
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                }
                var sql = GetUpdateStoredProcedureName(entity) + " " + pro;

                await con.ExecuteAsync(sql, parameters);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task DeleteAsync(T entity)
        {
            try
            {
                var sql = GetDeleteStoredProcedureName(entity) + " @Id";
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                }
                await con.ExecuteAsync(sql, parameters);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<T> ValidateAsync(T entity)
        {
            try
            {
                var sql = GetSelectStoredProcedureName(entity) + "Validate @Username,@Password";
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                };
                var result = await con.QueryFirstOrDefaultAsync<T>(sql, parameters);
                con.Close();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string GetInsertStoredProcedureName(T entity)
        {
            return $"EXEC spInsert{entity.GetType().Name}";
        }

        private string GetSelectStoredProcedureName(T entity)
        {
            return $"EXEC spSelect{entity.GetType().Name}";
        }

        private string GetUpdateStoredProcedureName(T entity)
        {
            return $"EXEC spUpdate{entity.GetType().Name}";
        }

        private string GetDeleteStoredProcedureName(T entity)
        {
            return $"EXEC spDelete{entity.GetType().Name}";
        }
    }
}