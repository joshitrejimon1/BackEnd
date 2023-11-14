using FinalProject.Models;
using FinalProject.Repository;

namespace FinalProject.Service
{
    public class RoleService:IRoleService
    {
        IRepository<Role> _repository;

        public RoleService(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public List<Role> GetAll()
        {
            return _repository.Get().ToList();
        }
    }
}

