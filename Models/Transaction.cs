using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProject.Models
{
    public class Transaction
    {
        [Key]
        public long transactionId { get; set; }
        public DateTime date { get; set; }
        public double amount { get; set; }
        public TransactionType transactionType { get; set; }
        public Account account { get; set; }
        [ForeignKey("Account")] public long accNo { get; set; }




    }
}