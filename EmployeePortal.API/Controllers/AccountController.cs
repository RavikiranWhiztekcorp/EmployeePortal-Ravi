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
        private readonly AccountBALRepo _accountBALRepo;

        public AccountController()
        {
            _accountBALRepo = new AccountBALRepo();
        }
        //[HttpPost("login")]
        //public IActionResult Login([FromBody] User user)
        //{
        //    if (_accountBALRepo.ValidateUserCredentials(user.Username, user.Password))
        //    {
        //        return Ok("Login Successfull");
        //    }
        //    else
        //    {
        //        return Unauthorized("Invalid credentials");
        //    }
        //}

        [HttpGet("getallusers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _accountBALRepo.GetAllAsync();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user != null)
            {
                var data = await _accountBALRepo.Create(user);
                if (data)
                {
                    return Ok("Register Successfull");
                }
                else
                {
                    return Ok("Make sure the credentials are correct");
                }

            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            if (user != null)
            {
                var data =await _accountBALRepo.UserValidateUserCredentials(user);
                if (data)
                {
                    return Ok("Login Successfull");
                }
                else
                {
                    return Ok("Make sure the credentials are correct");
                }
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
    }
}
