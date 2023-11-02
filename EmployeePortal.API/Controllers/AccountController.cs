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
        private readonly AccountBALRepo _accountBALRepo;
        public AccountController()
        {
            _accountBALRepo = new AccountBALRepo();
        }
        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _accountBALRepo.GetAllAsync();
        }
        [HttpPost("GetUserById")]
        public async Task<User> GetByIdUser(User _user)
        {
            return await _accountBALRepo.GetByIdAsync(_user);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User _user)
        {
            if (_user != null)
            {
                var data = await _accountBALRepo.Create(_user);
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
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User _user)
        {
            if (_user != null)
            {
                var data = await _accountBALRepo.Update(_user);
                if (data)
                {
                    return Ok("Update Successfull");
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
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(User _user)
        {
            if (_user != null)
            {
                var data = await _accountBALRepo.Delete(_user);
                if (data)
                {
                    return Ok("Delete Successfull");
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
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(User _user)
        {
            if (_user != null)
            {
                var data =await _accountBALRepo.UserValidateUserCredentials(_user);
                if (data)
                {
                    return Ok("Login Successfully");
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
