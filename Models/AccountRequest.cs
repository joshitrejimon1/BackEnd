using System.ComponentModel.DataAnnotations;

namespace FinalProject.Model
{
    public class AccountRequest
    {
        [Key] public int requestId { get; set; }

        public string documentUrl { get; set; }
        public string photoUrl { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string uploadDate { get; set; }
    }
}
    

