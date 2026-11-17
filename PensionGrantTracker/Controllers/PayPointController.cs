using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PensionGrantTracker.Models;

namespace PensionGrantTracker.Controllers
{
    public class PayPointController
    {
        private DbHelper db = new DbHelper();

        public List<PayPoint> GetAll()
        {
            List<PayPoint> list = new List<PayPoint>();
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "SELECT * FROM pay_points ORDER BY name";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PayPoint p = new PayPoint();
                    p.Id = Convert.ToInt32(reader["id"]);
                    p.Name = reader["name"].ToString();
                    p.District = reader["district"].ToString();
                    list.Add(p);
                }
                reader.Close();
            }
            return list;
        }

        public void Add(PayPoint p)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "INSERT INTO pay_points (name, district) VALUES (@name, @district)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@district", p.District);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PayPoint p)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "UPDATE pay_points SET name=@name, district=@district WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@district", p.District);
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "DELETE FROM pay_points WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public bool HasBeneficiaries(int id)
        {
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM beneficiaries WHERE pay_point_id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
