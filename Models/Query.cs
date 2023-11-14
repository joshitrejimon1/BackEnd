using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProject.Models
{
    public class Query
    {
        [Key]
        public long queryId { get; set; }
        public string userQuery { get; set; }
        public string adminSolution { get; set; }
        public Admin admin { get; set; }
        [ForeignKey("Admin")] public long adminid { get; set; }
        public Customer customer { get; set; }
        [ForeignKey("Customer")] public long customerId { get; set; }
    }
}