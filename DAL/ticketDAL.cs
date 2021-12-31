using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class ticketDAL
    {

        DataConnection dc;
        SqlCommand cmd;
        //String conStr = "Data Source= DESKTOP-QLEJV95\\SQLEXPRESS; Initial Catalog=TourManagement; Integrated Security=True";
        String conStr = "Data Source= DESKTOP-CI36P6F; Initial Catalog = TourManagement; Integrated Security = True";
        public ticketDAL()
        {
            dc = new DataConnection();
        }

        public bool Insert(tblTicket tk, ref String MaVe)
        {
            string sql = "INSERT INTO Ve(MaPhieu, GiaVe, MaDuKhach) VALUES ( @MaPhieu, @GiaVe, @MaDuKhach) SELECT SCOPE_IDENTITY()";
            //SqlConnection con = new  SqlConnection(conStr);
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaPhieu", tk.MaPhieu);
                cmd.Parameters.AddWithValue("@GiaVe", tk.GiaVe);
                cmd.Parameters.AddWithValue("@MaDuKhach", tk.MaDuKhach);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                MaVe = table.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            } return true;
        }
        public bool Update(tblTicket tk)
        {
            string sql = "UPDATE Ve SET MaPhieu = @MaPhieu, GiaVe = @GiaVe, MaDuKhach = @MaDuKhach WHERE MaVe = @MaVe";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaVe", SqlDbType.NVarChar).Value = tk.MaVe;
                cmd.Parameters.Add("@MaPhieu", SqlDbType.NVarChar).Value = tk.MaPhieu;
                cmd.Parameters.Add("@GiaVe", SqlDbType.Money).Value = tk.GiaVe;
                cmd.Parameters.Add("@MaDuKhach", SqlDbType.NVarChar).Value = tk.MaDuKhach;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool Delete(tblTicket tk)
        {
            string sql = "DELETE Ve WHERE MaVe = @MaVe";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaVe", SqlDbType.NVarChar).Value = tk.MaVe;
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
