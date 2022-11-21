using Microsoft.EntityFrameworkCore;

namespace RepositoryDB
{
    public class DB : DbContext
    {
        public static string? connectionString;

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
                if(connectionString == null)
                    throw new ArgumentNullException(nameof(connectionString));

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
