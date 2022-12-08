using Microsoft.EntityFrameworkCore;
using System.Text;

namespace RepositoryDB
{
    public class DB : DbContext
    {
        private static string? connectionString;
        public static string ConnectionString 
        { 
            set 
            {
                if (value == nuul)
                {
                    throw new Exception.ArgumentNullException(nameof(ConnectionString));
                }
                else
                {
                    connectionString = value;
                }
            } 
        }

        public DB()
        {
            Database.EnsureCreated();
        }
        public DB(string script)
        {
            if (Database.EnsureCreated())
            {
                Database.ExecuteSqlRaw(script);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        public static bool CheckDB(string script)
        {
            try
            {
                using (new DB(script)) { }
                return true;
            }
            catch
            {
                return false;
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

        public static string? GetSqlScript(string file)
        {
            string sqlScript = null;

            if (file != null || file != "")
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Exists)
                {
                    byte[] sqlScriptBytes = new byte[fileInfo.Length];
                    using (FileStream fstream = System.IO.File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fstream.Read(sqlScriptBytes);
                    }
                    sqlScript = Encoding.UTF8.GetString(sqlScriptBytes);
                }
            }

            return sqlScript;
        }
    }
}
