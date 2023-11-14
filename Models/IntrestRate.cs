using System.ComponentModel.DataAnnotations;
namespace FinalProject.Models
{
    public class InterestRate
    {
        [Key] public int rateId { get; set; }
        public int interestRate { get; set; }
    }
}