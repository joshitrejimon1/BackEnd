using FinalProject.Models;

namespace FinalProject.Service
{
    public interface IAccountService
    {
        public void Add(Account account);
        public Account GetAccountById(long accNo);
        public List<Account> GetAllAccounts();
    }
}
