using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Service
{
    public class CustomerService:ICustomerService
    {
        private IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;

        }
        public List<Customer> GetAll()
        {
            var customers = _repository.Get()
        .Include(c => c.accounts)
        .Include(c => c.user)
        .ToList();

            return customers;
        }

        public Customer GetById(long id)
        {
            return _repository.Get().SingleOrDefault(customer => customer.customerId == id);
        }

        public Customer Create(Customer customer)
        {
            _repository.Add(customer);
            return customer;
        }

        public Customer Update(Customer customer)
        {
            var existingCustomer = GetById(customer.customerId);

            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }

            existingCustomer.firstName = customer.firstName;
            existingCustomer.lastName = customer.lastName;
            existingCustomer.email = customer.email;

            _repository.Update(existingCustomer);

            return existingCustomer;
        }

        public bool Delete(Customer customer)
        {
            if (customer != null)
            {
                _repository.Delete(customer);
                return true;
            }
            return false;
        }
    }
}

