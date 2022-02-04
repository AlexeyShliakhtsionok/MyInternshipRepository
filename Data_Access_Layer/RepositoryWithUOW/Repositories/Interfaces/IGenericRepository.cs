using System.Linq.Expressions;

namespace Data_Access_Layer.RepositoryWithUOW.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
    }
}
