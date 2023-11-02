using EmployeePortal.Common.Models;
using EmployeePortal.Common.Models.Account;
using EmployeePortal.UI.Common;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private ApiService _apiService;
        public EmployeeController(ApiService apiService)
        {
            this._apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Employee>("api/Employee/GetAllEmployees");
            return View(employees);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
