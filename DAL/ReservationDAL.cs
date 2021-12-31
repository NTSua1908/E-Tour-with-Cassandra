using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class ReservationDAL
    {
        DataConnection dc;
        SqlCommand cmd;
        public ReservationDAL()
        {
            //dc = new DataConnection();
        }
        public bool Insert(Reservation res, ref String MaPhieu)
        {
            string sql = "INSERT INTO PhieuDatCho(MaChuyen) VALUES (@MaChuyen) SELECT SCOPE_IDENTITY()";
            SqlConnection con = null;// dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaChuyen", res.MaChuyen);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                MaPhieu = table.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Delete(Reservation res)
        {
            string sql = "DELETE PhieuDatCho WHERE MaPhieu = @MaPhieu";
            SqlConnection con = null;// dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhieu", SqlDbType.NVarChar).Value = res.MaPhieu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
