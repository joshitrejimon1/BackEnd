using FinalProject.DTO;
using FinalProject.Models;
using FinalProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost("deposit")]
        public IActionResult MakeDeposit([FromBody] TransactionDto transactionDto)
        {
            try
            {
                _transactionService.MakeDeposit(transactionDto, TransactionType.Deposit);
                return Ok("Deposit successful");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("withdrawal")]
        public IActionResult MakeWithdrawal([FromBody] TransactionDto transactionDto)
        {
            try
            {
                _transactionService.MakeWithdrawal(transactionDto, TransactionType.Withdrawal); return Ok("Withdrawal successful");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("transfer")]
        public IActionResult MakeTransfer([FromBody] WithdrawDto withdrawDto)
        {
            try
            {
                _transactionService.MakeTransfer(withdrawDto, TransactionType.Transfer);
                return Ok("Transfer successful");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

