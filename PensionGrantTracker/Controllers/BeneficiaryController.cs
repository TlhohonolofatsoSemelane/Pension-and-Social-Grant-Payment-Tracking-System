using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PensionGrantTracker.Models;

namespace PensionGrantTracker.Controllers
{
    public class BeneficiaryController
    {
        private DbHelper db = new DbHelper();

        private string baseSql = "SELECT b.id, b.full_name, b.national_id, b.phone, b.district, b.village, b.grant_type, b.monthly_amount, b.status, b.pay_point_id, p.name AS pay_point_name FROM beneficiaries b JOIN pay_points p ON b.pay_point_id = p.id ";

        private List<Beneficiary> ReadList(MySqlCommand cmd)
        {
            List<Beneficiary> list = new List<Beneficiary>();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Beneficiary b = new Beneficiary();
                b.Id = Convert.ToInt32(reader["id"]);
                b.FullName = reader["full_name"].ToString();
                b.NationalId = reader["national_id"].ToString();
                b.Phone = reader["phone"].ToString();
                b.District = reader["district"].ToString();
                b.Village = reader["village"].ToString();
                b.GrantType = reader["grant_type"].ToString();
                b.MonthlyAmount = Convert.ToDecimal(reader["monthly_amount"]);
                b.Status = reader["status"].ToString();
                b.PayPointId = Convert.ToInt32(reader["pay_point_id"]);
                b.PayPointName = reader["pay_point_name"].ToString();
                list.Add(b);
            }
            reader.Close();
            return list;
        }

        private void AddParameters(MySqlCommand cmd, Beneficiary b)
        {
            cmd.Parameters.AddWithValue("@name", b.FullName);
            cmd.Parameters.AddWithValue("@nid", b.NationalId);
            if (b.Phone == "")
            {
                cmd.Parameters.AddWithValue("@phone", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@phone", b.Phone);
            }
            cmd.Parameters.AddWithValue("@district", b.District);
            cmd.Parameters.AddWithValue("@village", b.Village);
            cmd.Parameters.AddWithValue("@type", b.GrantType);
            cmd.Parameters.AddWithValue("@amount", b.MonthlyAmount);
            cmd.Parameters.AddWithValue("@status", b.Status);
            cmd.Parameters.AddWithValue("@payPoint", b.PayPointId);
        }

        public List<Beneficiary> GetAll()
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(baseSql + "ORDER BY b.full_name", con);
                return ReadList(cmd);
            }
        }

        public List<Beneficiary> Search(string text)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = baseSql + "WHERE b.full_name LIKE @text OR b.national_id LIKE @text OR b.village LIKE @text ORDER BY b.full_name";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@text", "%" + text + "%");
                return ReadList(cmd);
            }
        }

        public void Add(Beneficiary b)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "INSERT INTO beneficiaries (full_name, national_id, phone, district, village, grant_type, monthly_amount, status, pay_point_id) VALUES (@name, @nid, @phone, @district, @village, @type, @amount, @status, @payPoint)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                AddParameters(cmd, b);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Beneficiary b)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "UPDATE beneficiaries SET full_name=@name, national_id=@nid, phone=@phone, district=@district, village=@village, grant_type=@type, monthly_amount=@amount, status=@status, pay_point_id=@payPoint WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                AddParameters(cmd, b);
                cmd.Parameters.AddWithValue("@id", b.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "DELETE FROM beneficiaries WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public bool NationalIdExists(string nationalId, int excludeId)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM beneficiaries WHERE national_id=@nid AND id<>@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nid", nationalId);
                cmd.Parameters.AddWithValue("@id", excludeId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public bool HasPayments(int id)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM payments WHERE beneficiary_id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
