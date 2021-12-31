using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
namespace Tour
{
    class TuyenDAL
    {
        DataConnection dc;
        SqlCommand cmd;
        SqlDataAdapter da;
        public TuyenDAL()
        {
            //dc = new DataConnection();
        }
        public DataTable getAllTuyen()
        {
            string sql = " Select ID, MaTuyen, TenTuyen, XuatPhat, DiaDiem, ThoiGianToChuc, TenLoaiTuyen from Tuyen inner join LoaiTuyen on Tuyen.MaLoaiTuyen = LoaiTuyen.MaLoaiTuyen";
            SqlConnection con = null;// dc.getConnect();
            da = new SqlDataAdapter(sql,con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertTuyen(tblTuyen route)
        {
            string sql = "Insert into Tuyen(MaTuyen, TenTuyen, XuatPhat, DiaDiem, MaLoaiTuyen,  ThoiGianToChuc) values(@MaTuyen,@TenTuyen, @XuatPhat, @DiaDiem, @MaLoaiTuyen, @ThoiGianToChuc)";
            SqlConnection con = null;// dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaTuyen",SqlDbType.NVarChar).Value=route.MaTuyen;
                cmd.Parameters.Add("@TenTuyen", SqlDbType.NVarChar).Value = route.TenTuyen;
                cmd.Parameters.Add("@XuatPhat", SqlDbType.NVarChar).Value = route.XuatPhat;
                cmd.Parameters.Add("@DiaDiem", SqlDbType.NVarChar).Value = route.DiaDiem;
                cmd.Parameters.Add("@MaLoaiTuyen", SqlDbType.NVarChar).Value = route.MaLoaiTuyen;
                cmd.Parameters.Add("@ThoiGianToChuc", SqlDbType.NVarChar).Value = route.ThoiGianToChuc;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateTuyen(tblTuyen route)
        {
            string sql = "Update Tuyen set MaTuyen=@MaTuyen, TenTuyen=@TenTuyen, XuatPhat=@XuatPhat, DiaDiem=@DiaDiem, MaLoaiTuyen=@MaLoaiTuyen, ThoiGianToChuc=@ThoiGianToChuc where ID=@ID";
            SqlConnection con = null;// dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = route.ID;
                cmd.Parameters.Add("@MaTuyen", SqlDbType.NVarChar).Value = route.MaTuyen;
                cmd.Parameters.Add("@TenTuyen", SqlDbType.NVarChar).Value = route.TenTuyen;
                cmd.Parameters.Add("@XuatPhat", SqlDbType.NVarChar).Value = route.XuatPhat;
                cmd.Parameters.Add("@DiaDiem", SqlDbType.NVarChar).Value = route.DiaDiem;
                cmd.Parameters.Add("@MaLoaiTuyen", SqlDbType.NVarChar).Value = route.MaLoaiTuyen;
                cmd.Parameters.Add("@ThoiGianToChuc", SqlDbType.NVarChar).Value = route.ThoiGianToChuc;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteTuyen(tblTuyen route)
        {
            string sql = "Delete Tuyen where ID=@ID";
            SqlConnection con = null; // c.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = route.ID;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable FindTuyen(string route)
        {
            string sql = "Select ID, MaTuyen, TenTuyen, XuatPhat, DiaDiem, ThoiGianToChuc, TenLoaiTuyen from Tuyen inner join LoaiTuyen on Tuyen.MaLoaiTuyen = LoaiTuyen.MaLoaiTuyen where TenTuyen like N'%" + route + "%'OR MaTuyen like N'%" + route + "%'";
            SqlConnection con = null; // dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
