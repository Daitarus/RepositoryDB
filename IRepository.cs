namespace RepositoryDB
{
    public interface IRepository<T>
    {
        T? SelectId(int id);
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> SelectAll();
        void SaveChange();
    }
}
