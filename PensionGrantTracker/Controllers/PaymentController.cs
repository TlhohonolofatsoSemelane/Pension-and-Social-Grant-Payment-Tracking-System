using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PensionGrantTracker.Models;

namespace PensionGrantTracker.Controllers
{
    public class PaymentController
    {
        private DbHelper db = new DbHelper();

        private string baseSql = "SELECT p.id, p.beneficiary_id, b.full_name, pp.name AS pay_point_name, p.payment_month, p.amount, p.status, p.paid_date, p.delay_reason FROM payments p JOIN beneficiaries b ON p.beneficiary_id = b.id JOIN pay_points pp ON b.pay_point_id = pp.id ";

        private List<Payment> ReadList(MySqlCommand cmd)
        {
            List<Payment> list = new List<Payment>();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment p = new Payment();
                p.Id = Convert.ToInt32(reader["id"]);
                p.BeneficiaryId = Convert.ToInt32(reader["beneficiary_id"]);
                p.BeneficiaryName = reader["full_name"].ToString();
                p.PayPointName = reader["pay_point_name"].ToString();
                p.PaymentMonth = reader["payment_month"].ToString();
                p.Amount = Convert.ToDecimal(reader["amount"]);
                p.Status = reader["status"].ToString();
                if (reader["paid_date"] != DBNull.Value)
                {
                    p.PaidDate = Convert.ToDateTime(reader["paid_date"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    p.PaidDate = "";
                }
                p.DelayReason = reader["delay_reason"].ToString();
                list.Add(p);
            }
            reader.Close();
            return list;
        }

        public List<Payment> GetByMonth(string month, string status)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = baseSql + "WHERE p.payment_month = @month";
                if (status != "All")
                {
                    sql = sql + " AND p.status = @status";
                }
                sql = sql + " ORDER BY b.full_name";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@month", month);
                if (status != "All")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                }
                return ReadList(cmd);
            }
        }

        public List<Payment> GetNotPaid(string month)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = baseSql + "WHERE p.payment_month = @month AND p.status <> 'Paid' ORDER BY p.status, b.full_name";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@month", month);
                return ReadList(cmd);
            }
        }

        public List<Payment> GetByBeneficiary(int beneficiaryId)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = baseSql + "WHERE p.beneficiary_id = @id ORDER BY p.payment_month DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", beneficiaryId);
                return ReadList(cmd);
            }
        }

        public int CreateForMonth(string month)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "INSERT INTO payments (beneficiary_id, payment_month, amount, status) SELECT b.id, @month, b.monthly_amount, 'Pending' FROM beneficiaries b WHERE b.status = 'Active' AND NOT EXISTS (SELECT 1 FROM payments p WHERE p.beneficiary_id = b.id AND p.payment_month = @month)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@month", month);
                return cmd.ExecuteNonQuery();
            }
        }

        public void MarkPaid(int id, DateTime paidDate)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "UPDATE payments SET status='Paid', paid_date=@date, delay_reason=NULL WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@date", paidDate);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void MarkDelayed(int id, string reason)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "UPDATE payments SET status='Delayed', paid_date=NULL, delay_reason=@reason WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void MarkPending(int id)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "UPDATE payments SET status='Pending', paid_date=NULL, delay_reason=NULL WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "DELETE FROM payments WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
