using System;
using MySql.Data.MySqlClient;
using PensionGrantTracker.Models;

namespace PensionGrantTracker.Controllers
{
    public class ReportController
    {
        private DbHelper db = new DbHelper();

        public MonthSummary GetSummary(string month)
        {
            MonthSummary s = new MonthSummary();
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "SELECT COUNT(*) AS total, " +
                    "IFNULL(SUM(CASE WHEN status = 'Paid' THEN 1 ELSE 0 END), 0) AS paid, " +
                    "IFNULL(SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END), 0) AS pending, " +
                    "IFNULL(SUM(CASE WHEN status = 'Delayed' THEN 1 ELSE 0 END), 0) AS delayed, " +
                    "IFNULL(SUM(CASE WHEN status = 'Paid' THEN amount ELSE 0 END), 0) AS amount_paid, " +
                    "IFNULL(SUM(CASE WHEN status <> 'Paid' THEN amount ELSE 0 END), 0) AS amount_to_pay " +
                    "FROM payments WHERE payment_month = @month";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s.Total = Convert.ToInt32(reader["total"]);
                    s.Paid = Convert.ToInt32(reader["paid"]);
                    s.Pending = Convert.ToInt32(reader["pending"]);
                    s.Delayed = Convert.ToInt32(reader["delayed"]);
                    s.AmountPaid = Convert.ToDecimal(reader["amount_paid"]);
                    s.AmountToPay = Convert.ToDecimal(reader["amount_to_pay"]);
                }
                reader.Close();
            }
            return s;
        }
    }
}
