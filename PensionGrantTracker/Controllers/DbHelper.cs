using MySql.Data.MySqlClient;

namespace PensionGrantTracker.Controllers
{
    public class DbHelper
    {
        private string connectionString = "server=localhost;port=3306;database=pension_grant_db;user=root;password=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
