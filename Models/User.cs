using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProject.Models
{
    public class User
    {
        [Key]
        public long userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public Customer customer { get; set; }
        public Role role { get; set; }
        [ForeignKey("Role")] public long roleId { get; set; }
        public Admin admin { get; set; }
    }
}