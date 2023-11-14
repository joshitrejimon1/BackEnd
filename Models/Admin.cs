using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Admin
    {
        [Key]
        public long adminId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public User user { get; set; }

        [ForeignKey("User")]
        public long userId { get; set; }
        public List<Query> query { get; set; }


    }
}