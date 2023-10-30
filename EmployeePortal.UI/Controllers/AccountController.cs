using EmployeePortal.Common.Models.Account;
using EmployeePortal.UI.Common;
using EmployeePortal.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.UI.Controllers
{
    public class AccountController : Controller
    {
        private ApiService _apiService;
        public AccountController(ApiService apiService)
        {
            this._apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Username = model.Username;
                user.Password = model.Password;

                // Make a POST request to the Web API
                var response = await _apiService.PostAsync("api/Account/login", user);
                if (!string.IsNullOrEmpty(response) && response == "Login Successfull")
                {
                    // Handle a successful login
                    ViewBag.Username = model.Username.ToString();
                    return RedirectToAction("Welcome");
                }
                else
                {
                    // Handle the case where the API request fails or login is unsuccessful
                    ModelState.AddModelError(string.Empty, response);
                    ModelState.AddModelError(string.Empty, "API request failed or login was unsuccessful");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Username = model.Username;
                user.Password = model.Password;
                user.Email = model.Email;
                user.Role = "User";
                user.CreatedDate = DateTime.Now;
                user.UpdatedDate = DateTime.Now;

                // Make a POST request to the Web API
                var response = await _apiService.PostAsync("api/Account/register", user);

                if (!string.IsNullOrEmpty(response) && response == "Register Successfull")
                {
                    // Handle a successful Register
                    return RedirectToAction("Login");
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
            return View(model);
        }
        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MyTask()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyTaskAsync(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Make a POST request to the Web API
                var response = await _apiService.PostAsync("api/Account/mytask", model);

                if (!string.IsNullOrEmpty(response) && response == "Successfull")
                {
                    // Handle a successful Register
                    return RedirectToAction("MyTask");
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
            return View(model);
        }

    }
}
