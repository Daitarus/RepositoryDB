using Microsoft.EntityFrameworkCore;

namespace RepositoryDB
{
    public class DB : DbContext
    {
        private readonly string connectionString;
        public DB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString != null)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public static bool CheckDB()
        {
            try
            {
                using (new DB()) { }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
