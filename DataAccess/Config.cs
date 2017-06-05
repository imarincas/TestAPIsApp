using System.Configuration;

namespace DataAccess
{
   public class Config
    {
        public static class ConnectionStings
        {
            public static string AppDatabase = ConfigurationManager.ConnectionStrings["AppDatabaseConnectionString"].ConnectionString;
        }
    }
}
