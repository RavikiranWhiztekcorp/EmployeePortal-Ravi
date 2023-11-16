using EmployeePortal.Common.Models;
using EmployeePortal.Common.Models.Account;
using EmployeePortal.UI.Common;
using EmployeePortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PagedList;

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
            TempData["message"] = "This is Employee Index";

            var employees = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Employee>("api/Employee/GetAllEmployees");
            ViewData["department"] = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Department>("api/Department/GetAllDepartments");
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["department"] = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Department>("api/Department/GetAllDepartments");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Email = model.Email;
                employee.PhoneNo = model.PhoneNo;
                employee.Age = model.Age;
                employee.AadharNo = model.AadharNo;
                employee.Salary = model.Salary;
                employee.Address = model.Address;
                employee.DepartmentId =model.DepartmentId;
                employee.CreatedDate= DateTime.Now;
                employee.UpdatedDate= DateTime.Now;
                // Make a POST request to the Web API
                var response = await _apiService.PostAsync("api/Employee/CreateEmployee", employee);

                if (!string.IsNullOrEmpty(response) && response == "Employee Registred Successfull" || response == "true")
                {
                    TempData["message"] = response;
                    // Handle a successful Register
                    return RedirectToAction("Index");
                }
                else
                {

                    // Handle the case where the API request fails or register is unsuccessful
                    if (response != null)
                    {
                        ModelState.AddModelError(string.Empty, response);
                    }
                    ModelState.AddModelError(string.Empty, "API request failed or register was unsuccessful");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var data = await _apiService.PostAsync<EmployeePortal.Common.Models.Employee, EmployeePortal.Common.Models.Employee>("api/Employee/GetEmployeeById", new Employee() { Id=Id,FirstName="string",LastName="string",Email="string",Address="string"});
            ViewData["department"] = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Department>("api/Department/GetAllDepartments");
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                // Make a POST request to the Web API
                var response = await _apiService.PutAsync("api/Employee/UpdateEmployee", model);

                if (!string.IsNullOrEmpty(response) && response == "Employee Updated Successfull" || response == "true")
                {
                    TempData["message"] = response;
                    // Handle a successful Updated
                    return RedirectToAction("Index");
                }
                else
                {

                    // Handle the case where the API request fails or register is unsuccessful
                    if (response != null)
                    {
                        ModelState.AddModelError(string.Empty, response);
                    }
                    ModelState.AddModelError(string.Empty, "API request failed or register was unsuccessful");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            return View("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var data = await _apiService.PostAsync<EmployeePortal.Common.Models.Employee, EmployeePortal.Common.Models.Employee>("api/Employee/GetEmployeeById", new Employee() { Id = Id, FirstName = "string", LastName = "string", Email = "string", Address = "string" });
            ViewData["department"] = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Department>("api/Department/GetAllDepartments");
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _apiService.PostAsync<EmployeePortal.Common.Models.Employee, EmployeePortal.Common.Models.Employee>("api/Employee/GetEmployeeById", new Employee() { Id = Id, FirstName = "string", LastName = "string", Email = "string", Address = "string" });
            ViewData["department"] = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Department>("api/Department/GetAllDepartments");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            var response = await _apiService.PostAsync<EmployeePortal.Common.Models.Employee>("api/Employee/DeleteEmployee", new Employee() { Id = employee.Id, FirstName = "string", LastName = "string", Email = "string", Address = "string" });
            if (!string.IsNullOrEmpty(response) && response == "true")
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where the API request fails or register is unsuccessful
                if (response != null)
                {
                    TempData["message"] = "Employee Deleted Successfully";
                    ModelState.AddModelError(string.Empty, response);
                }
                ModelState.AddModelError(string.Empty, "API request failed or register was unsuccessful");
            }
            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            return View("Delete", employee);
        }
    }
}
