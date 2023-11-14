using FinalProject.Models;

namespace FinalProject.Service
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(long id);
        public User Add(User user);
        public User Update(User user);
        public bool Delete(long id);
    }
}
