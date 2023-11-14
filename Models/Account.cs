using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace FinalProject.Models
{
    public class Account
    {
        [Key]
        public long accNo { get; set; }
        public double balance { get; set; }

        public List<Transaction> transactions { get; set; }

        public AccountType accountType { get; set; }

        public Customer customer { get; set; }
        [ForeignKey("Customer")]
        public long customerId { get; set; }
    }
}