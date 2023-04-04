using Microsoft.EntityFrameworkCore;

namespace BikeRental.DAL
{
    public class RepositoryService<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        public RepositoryService(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _set.Add(entity);
            Save();
        }
        public IQueryable<T> GetAllRecords()
        {
            return _set;
        }
        public T GetSingle(Guid id)
        {
            return _set.Find(id); //?????????

        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public void Delete(T entity)
        {
            _set.Remove(entity);
            Save();
        }
    }
}
