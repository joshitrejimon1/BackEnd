using FinalProject.DTO;
using FinalProject.Models;
using FinalProject.Repository;

namespace FinalProject.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Customer> _customerRepository;

        public TransactionService(IRepository<Transaction> transactionRepository, IRepository<Account> accountRepository, IRepository<Customer> customerRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        public void MakeDeposit(TransactionDto transactionDto, TransactionType deposit)
        {
            var account = _accountRepository.Get().FirstOrDefault(a => a.accNo == transactionDto.AccNo);

            if (account == null)
            {
                throw new InvalidOperationException("Account not found");
            }

            double amount = transactionDto.Amount;

            double currentBalance = account.balance;
            double newBalance = currentBalance + amount;
            account.balance = newBalance;

            _accountRepository.Update(account);

            Transaction transaction = new Transaction
            {
                date = DateTime.Now,
                amount = amount,
                account = account,
                transactionType = deposit,
                accNo = transactionDto.AccNo,
            };

            _transactionRepository.Add(transaction);
        }
        public void MakeWithdrawal(TransactionDto transactionDto, TransactionType withdrawal)
        {
            var account = _accountRepository.Get().FirstOrDefault(a => a.accNo == transactionDto.AccNo);

            if (account == null)
            {
                throw new InvalidOperationException("Account not found");
            }

            double amount = transactionDto.Amount;

            double currentBalance = account.balance;
            double newBalance = currentBalance - amount;
            account.balance = newBalance;

            _accountRepository.Update(account);

            Transaction transaction = new Transaction
            {
                date = DateTime.Now,
                amount = amount,
                account = account,
                transactionType = withdrawal,
                accNo = account.accNo
            };

            _transactionRepository.Add(transaction);
        }
        public void MakeTransfer(WithdrawDto withdrawDto, TransactionType transfer)
        {
            var sourceAccount = _accountRepository.Get().FirstOrDefault(a => a.accNo == withdrawDto.SourceAccNo);
            var targetAccount = _accountRepository.Get().FirstOrDefault(a => a.accNo == withdrawDto.TargetAccNo);

            if (sourceAccount == null || targetAccount == null)
            {
                throw new InvalidOperationException("One or both accounts not found");
            }

            double amount = withdrawDto.Amount;

            sourceAccount.balance -= amount;
            targetAccount.balance += amount;

            _accountRepository.Update(sourceAccount);
            _accountRepository.Update(targetAccount);

            Transaction transaction = new Transaction
            {
                date = DateTime.Now,
                amount = amount,
                transactionType = transfer,
                account = sourceAccount,
                accNo = sourceAccount.accNo,
            };

            _transactionRepository.Add(transaction);
        }
    }
}

