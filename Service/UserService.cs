using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Service
{
    public class UserService:IUserService
    {
        IRepository<User> _repository;


        public UserService(IRepository<User> repository)

        {
            _repository = repository;

        }
        public List<User> GetAll()
        {
            return _repository.Get().Include(u => u.role).ToList();
        }


        public User GetById(long id)
        {
            var user = _repository.Get()
                .Include(u => u.role)  // Include the 'role' navigation property 
                .FirstOrDefault(u => u.userId == id);

            if (user != null)
            {
                _repository.Detach(user);
            }

            return user;
        }

        public User Add(User user)
        {
            _repository.Add(user);
            return user;
        }
        public User Update(User user)
        {
            return _repository.Update(user);

        }
        public bool Delete(long id)
        {
            var usertd = GetById(id);
            if (usertd != null)
            {
                _repository.Delete(usertd);
                return true;
            }
            return false;
        }


    }
}

