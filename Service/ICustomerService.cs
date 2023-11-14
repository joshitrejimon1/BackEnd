using FinalProject.Models;

namespace FinalProject.Service
{
    public interface ICustomerService
    {
        public List<Customer> GetAll();
        public bool Delete(Customer customer);
        public Customer Update(Customer customer);
        public Customer Create(Customer customer);
        public Customer GetById(long id);
    }
}
