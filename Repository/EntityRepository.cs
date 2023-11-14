using FinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private MyContext _context;
        private DbSet<T> _table;

        public EntityRepository(MyContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IQueryable<T> Get()
        {
            return _table.AsQueryable();
        }

        //public T GetById(int id) 
        //{ 
        //    T existing=_table.Find(id); 
        //    if (existing != null) 
        //        _context.Entry(existing).State = EntityState.Detached; 
        //    return existing; 
        //} 
        public T GetById(long id)
        {
            return _table.Find(id);
        }
        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            var isActiveProperty = entity.GetType().GetProperty("IsActive");
            if (isActiveProperty != null)
            {
                isActiveProperty.SetValue(entity, false);
                _table.Update(entity);
            }
            else
                _table.Remove(entity);
            _context.SaveChanges();
        }
    }
}