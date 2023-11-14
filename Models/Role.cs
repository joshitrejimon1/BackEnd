using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Role
    {
        [Key]
        public long roleId { get; set; }
        public string roleName { get; set; }

        public List<User> user { get; set; }

    }
}