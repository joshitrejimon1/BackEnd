using FinalProject.DTO;
using FinalProject.Models;

namespace FinalProject.Service
{
    public interface ITransactionService
    {
       
     
        public void MakeWithdrawal(TransactionDto transactionDto, TransactionType withdrawal);
        public void MakeTransfer(WithdrawDto withdrawDto, TransactionType transfer);
        public void MakeDeposit(TransactionDto transactionDto, TransactionType deposit);


    }
}
