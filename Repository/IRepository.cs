namespace FinalProject.Repository
{
    public interface IRepository<T>
    {
        public IQueryable<T> Get();
        public void Detach(T entity);
        public int Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
        public T GetById(long id);
    }
}
