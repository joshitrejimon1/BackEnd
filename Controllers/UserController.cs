using FinalProject.DTO;
using FinalProject.Models;
using FinalProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService; private readonly IAccountService _accountService;
        public UsersController(IUserService userService, ICustomerService customerService, IAccountService accountService)
        {
            _userService = userService;
            _customerService = customerService; _accountService = accountService;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            var userDtos = users.Select(user => ConvertToUserDto(user)); return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var userDto = ConvertToUserDto(user); return Ok(userDto);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            var addedUser = _userService.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = addedUser.userId }, addedUser);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, [FromBody] User user)
        {
            var existingUser = _userService.GetById(id); if (existingUser == null)
            {
                return NotFound("User not found");
            }
            user.userId = id; var updatedUser = _userService.Update(user);
            return Ok(updatedUser);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            var isDeleted = _userService.Delete(id); if (!isDeleted)
            {
                return NotFound("User not found");
            }
            return NoContent();
        }
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] LoginDto loginDto)
        {
            var user = ConvertToUser(loginDto);
            var addedUser = _userService.Add(user);
            var customer = ConvertToCustomer(loginDto);
            customer.userId = addedUser.userId;
            // Assuming you have a service method for adding customers            var addedCustomer = _customerService.Create(customer);
            // Create and add an account
            var account = CreateAccount(customer.customerId); _accountService.Add(account);

            return CreatedAtAction(nameof(GetUserById), new { id = addedUser.userId }, addedUser);
        }
        private Account CreateAccount(long customerId)
        {
            return new Account
            {
                balance = 0,
                accountType = AccountType.Savings,
                customerId= customerId
            };
        }
        private User ConvertToUser(LoginDto loginDto)
        {
            return new User
            {
                userName = loginDto.UserName,
                password = loginDto.Password,
                roleId = 2
            };
        }

        private Customer ConvertToCustomer(LoginDto loginDto)
        {
            return new Customer
            {
                firstName = loginDto.FirstName,
                lastName = loginDto.LastName,
                email = loginDto.Email,
            };
        }
        private UserDto ConvertToUserDto(User user)
        {
            return new UserDto
            {
                userId = user.userId,
                userName = user.userName,
                password = user.password,
                roleName = user.role?.roleName
            };
        }
    }
}
