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
                user.Password= model.Password;
                
                // Make a POST request to the Web API
                var response = await _apiService.PostAsync("api/Account/login", user);
                if (!string.IsNullOrEmpty(response) && response == "Login Successfull")
                {
                    // Handle a successful login
                    return RedirectToAction("Welcome");
                }
                else
                {
                    // Handle the case where the API request fails or login is unsuccessful
                    ModelState.AddModelError(string.Empty, "API request failed or login was unsuccessful");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(model);
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }
    }

}
