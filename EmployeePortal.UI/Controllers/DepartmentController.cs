using EmployeePortal.Common.Models;
using EmployeePortal.UI.Common;
using EmployeePortal.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private ApiService _apiService;
        public DepartmentController(ApiService apiService)
        {
            this._apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["message"] = "This is Department Index";

            var Departments = await _apiService.GetAllAsync<EmployeePortal.Common.Models.Department>("api/Department/GetAllDepartments");
            return View(Departments);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();
                department.Id = model.Id;
                department.DepartmentName = model.DepartmentName;
                department.CreatedDate = DateTime.Now;
                department.UpdatedDate = DateTime.Now;
                // Make a POST request to the Web API
                var response = await _apiService.PostAsync("api/Department/CreateDepartment", department);

                if (!string.IsNullOrEmpty(response) && response == "Department Registred Successfull" || response == "true")
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
                    ModelState.AddModelError(string.Empty, "API request failed or Create was unsuccessful");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Create attempt");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var data = await _apiService.PostAsync<EmployeePortal.Common.Models.Department, EmployeePortal.Common.Models.Department>("api/Department/GetDepartmentById", new Department() { Id = Id, DepartmentName = string.Empty });
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department model)
        {
            if (ModelState.IsValid)
            {
                // Make a POST request to the Web API
                var response = await _apiService.PutAsync("/api/Department/UpdateDepartment", model);

                if (!string.IsNullOrEmpty(response) && response == "Department Updated Successfull" || response == "true")
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
                    ModelState.AddModelError(string.Empty, "API request failed or Update was unsuccessful");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Update attempt");
            return View("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var data = await _apiService.PostAsync<EmployeePortal.Common.Models.Department, EmployeePortal.Common.Models.Department>("api/Department/GetDepartmentById", new Department() { Id = Id, DepartmentName = string.Empty });
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _apiService.PostAsync<EmployeePortal.Common.Models.Department, EmployeePortal.Common.Models.Department>("api/Department/GetDepartmentById", new Department() { Id = Id, DepartmentName = string.Empty });
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Department department)
        {
            var response = await _apiService.PostAsync<EmployeePortal.Common.Models.Department>("/api/Department/DeleteDepartment", new Department() { Id = department.Id,DepartmentName="string"});
            if (!string.IsNullOrEmpty(response) && response == "true")
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where the API request fails or register is unsuccessful
                if (response != null)
                {
                    TempData["message"] = "Department Deleted Successfully";
                    ModelState.AddModelError(string.Empty, response);
                }
                ModelState.AddModelError(string.Empty, "API request failed or register was unsuccessful");
            }
            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            return View("Index");
        }
    }
}
