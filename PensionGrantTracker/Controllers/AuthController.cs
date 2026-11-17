using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace PensionGrantTracker.Controllers
{
    public class AuthController
    {
        private DbHelper db = new DbHelper();

        private string Hash(string text)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(text));
            return Convert.ToHexString(bytes).ToLower();
        }

        public bool Login(string username, string password)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE username=@user AND password_hash=@hash";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@hash", Hash(password));
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (!Login(username, oldPassword))
            {
                return false;
            }
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "UPDATE users SET password_hash=@hash WHERE username=@user";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@hash", Hash(newPassword));
                cmd.Parameters.AddWithValue("@user", username);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
    }
}
