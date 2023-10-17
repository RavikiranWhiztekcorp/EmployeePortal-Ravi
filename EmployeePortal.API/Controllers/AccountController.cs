using EmployeePortal.BAL.Implementations;
using EmployeePortal.Common.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //implement DI
        private readonly AccountBALRepo _accountBALRepo = new AccountBALRepo();

        public AccountController()
        {
            //_accountBALRepo = accountBALRepo;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (_accountBALRepo.ValidateUserCredentials(user.Username, user.Password))
            {
                return Ok("Login Successfull");
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
    }
}
