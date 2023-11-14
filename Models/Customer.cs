using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Customer
    {
        [Key]
        public long customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public List<Account> accounts { get; set; }

        public User user { get; set; }
        [ForeignKey("User")]
        public long userId { get; set; }
        public List<Query> query { get; set; }
    }
}