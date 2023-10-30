using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
