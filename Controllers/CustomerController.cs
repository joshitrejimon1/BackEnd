using FinalProject.Models;
using FinalProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        //public readonly IRepository<Customer> _ripository; 

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        //[HttpGet("nidhi")] 
        //public IActionResult GetS() 
        //{ 
        //    var customers = _ripository.Get(); 
        //    return Ok(customers); 
        //} 






        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var customer = _customerService.GetById(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound("Customer not found");
        }

        //private Customer ConvertToModel(TransactionDto transactionDto) 
        //{ 
        //    return new Customer() 
        //   { 
        //        customerId = customerDto.customerId, 
        //        balance = customerDto.balance, 

        //   }; 
        //} 
        //private CustomerDto ConvertToDto(Customer customer) 
        //{ 
        //    return new CustomerDto() 
        //    { 
        //        customerId = customer.customerId, 
        //        firstName = customer.firstName, 
        //        lastName = customer.lastName, 
        //        email = customer.email, 
        //        balance = customer.accounts != null ? customer.accounts.Count : 0 

        //    }; 
        //} 
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = _customerService.Create(customer);
            return CreatedAtAction(nameof(Get), new { id = createdCustomer.customerId }, createdCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(long id, [FromBody] Customer customer)
        {
            customer.customerId = id;
            var updatedCustomer = _customerService.Update(customer);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(long id)
        {
            var customer = _customerService.GetById(id);
            var success = _customerService.Delete(customer);

            if (success)
            {
                return Ok("Customer deleted successfully");
            }

            return NotFound("Customer not found");
        }
    }
}

