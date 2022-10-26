using Microsoft.EntityFrameworkCore;

namespace RepositoryDB
{
    public class DB : DbContext
    {
        private static string? connectionString;
        public static string ConnectionString { set { connectionString = value; } }

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
