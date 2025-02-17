﻿using EmployeePortal.BAL.Interfaces;
using EmployeePortal.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBALRepo _employeeBALRepo;
       public EmployeeController(IEmployeeBALRepo _empBALRepo)
        {
            _employeeBALRepo = _empBALRepo;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeBALRepo.GetAllEmployeesAsync();
        }
        [HttpPost("GetEmployeeById")]                                             
        public async Task<Employee> GetEmployeeByidAsync(Employee _employee)
        {
            return await _employeeBALRepo.GetEmployeeByidAsync(_employee);
        }
        [HttpPost("CreateEmployee")]
        public async Task<bool> Create(Employee _employee)
        {
            return await _employeeBALRepo.Create(_employee);

        }
        [HttpPut("UpdateEmployee")]
        public async Task<bool> Update(Employee _employee)
        {
            return await _employeeBALRepo.Update(_employee);

        }
        [HttpPost("DeleteEmployee")]
        public async Task<bool> Delete(Employee employee)
        {
            return await _employeeBALRepo.Delete(employee);
        }
    }
}
