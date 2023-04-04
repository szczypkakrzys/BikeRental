namespace BikeRental.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAllRecords();
        T GetSingle(Guid id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();

    }
}
