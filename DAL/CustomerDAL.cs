using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tour
{
    class CustomerDAL
    {
        DataConnection dc;
        SqlCommand cmd;
        public CustomerDAL()
        {
            dc = new DataConnection();
        }

        public bool InsertForeign(Customer cus, ref String MaDuKhach)
        {
            string sql = "INSERT INTO DuKhach(HoTen, DiaChi, SDT, MaLoaiKhach, GioiTinh, CMND_Passport, HanPassport, HanVisa ) VALUES (@HoTen, @DiaChi, @SDT, @MaLoaiKhach, @GioiTinh, @CMND_Passport,@HanPassport, @HanVisa) SELECT SCOPE_IDENTITY()";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@HoTen", cus.HoTen);
                cmd.Parameters.AddWithValue("@DiaChi", cus.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", cus.SDT);
                cmd.Parameters.AddWithValue("@MaLoaiKhach", cus.MaLoaiKhach);
                cmd.Parameters.AddWithValue("@GioiTinh", cus.GioiTinh);
                cmd.Parameters.AddWithValue("@CMND_Passport", cus.CMND_Passport);
                cmd.Parameters.AddWithValue("@HanPassport", cus.HanPassport);
                cmd.Parameters.AddWithValue("@HanVisa", cus.HanVisa);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                MaDuKhach = table.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool InsertDomestic(Customer cus, ref String MaDuKhach)
        {
            string sql = "INSERT INTO DuKhach(HoTen, DiaChi, SDT, MaLoaiKhach, GioiTinh, CMND_Passport) VALUES ( @HoTen, @DiaChi, @SDT, @MaLoaiKhach, @GioiTinh, @CMND_Passport) SELECT SCOPE_IDENTITY()";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@HoTen", cus.HoTen);
            cmd.Parameters.AddWithValue("@DiaChi", cus.DiaChi);
            cmd.Parameters.AddWithValue("@SDT", cus.SDT);
            cmd.Parameters.AddWithValue("@MaLoaiKhach", cus.MaLoaiKhach);
            cmd.Parameters.AddWithValue("@GioiTinh", cus.GioiTinh);
            cmd.Parameters.AddWithValue("@CMND_Passport", cus.CMND_Passport);
            //cmd.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            MaDuKhach = table.Rows[0][0].ToString();
            con.Close();
            return true;
        }

        public bool Update(Customer cus)
        {

            string sql = " UPDATE DuKhach SET  HoTen = @HoTen, DiaChi = @DiaChi, SDT = @SDT, MaLoaiKhach = @MaLoaiKhach, GioiTinh = @GioiTinh, CMND_Passport = @CMND_Passport WHERE MaDuKhach = @MaDuKhach";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaDuKhach", cus.MaDuKhach);
                cmd.Parameters.AddWithValue("@HoTen", cus.HoTen);
                cmd.Parameters.AddWithValue("@DiaChi", cus.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", cus.SDT);
                cmd.Parameters.AddWithValue("@MaLoaiKhach", cus.MaLoaiKhach);
                cmd.Parameters.AddWithValue("@GioiTinh", cus.GioiTinh);
                cmd.Parameters.AddWithValue("@CMND_Passport", cus.CMND_Passport);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool Delete(Customer cus)
        {
            string sql = "DELETE DuKhach WHERE MaDuKhach = @MaDuKhach";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDuKhach", SqlDbType.NVarChar).Value = cus.MaDuKhach;
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
