using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Service
{
    public class AccountService:IAccountService
    {
        private IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<Account> GetAllAccounts()
        {
            var accounts = _accountRepository.Get()
                    .Include(a => a.transactions)
                    .Include(a => a.customer)
                    .ThenInclude(c => c.user)
                    .ToList();

            return accounts;
        }

        public Account GetAccountById(long accNo)
        {
            return _accountRepository.Get().SingleOrDefault(account => account.accNo == accNo);
        }
        public void Add(Account account)
        {
            _accountRepository.Add(account);
        }

    }
}

