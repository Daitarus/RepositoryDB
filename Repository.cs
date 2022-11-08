namespace RepositoryDB
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DB db;
        public Repository(DB db)
        {
            this.db = db;
        }

        public T? SelectId(uint id)
        {
            return db.Find<T>(id);
        }
        public void Add(T entity)
        {
            db.Add(entity);
        }
        public void Remove(T entity)
        {
            db.Remove(entity);
        }
        public IQueryable<T> SelectAll()
        {
            return db.Set<T>();
        }
        public void SaveChange()
        {
            db.SaveChanges();
        }
    }
}
