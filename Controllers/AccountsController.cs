using FinalProject.Models;
using FinalProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("")]
        public IActionResult GetAllAccounts()
        {
            List<Account> accounts = _accountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpGet("{accNo}")]
        public IActionResult GetAccountById(long accNo)
        {
            Account account = _accountService.GetAccountById(accNo);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound("Account not found");
        }
    }
}
