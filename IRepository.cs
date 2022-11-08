namespace RepositoryDB
{
    public interface IRepository<T>
    {
        T? SelectId(uint id);
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> SelectAll();
        void SaveChange();
    }
}
