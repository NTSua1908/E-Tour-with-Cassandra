using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tour
{   
    class ChuyenDAL
    {
        DataConnection dc;
        SqlCommand cmd;
        SqlDataAdapter da;    
        public ChuyenDAL()
        {
            //dc = new DataConnection();
        }
        public bool LoadComboBox(ComboBox cb)
        {
            //SqlConnection con;// = dc.getConnect();
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Select MaTuyen From Tuyen",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            //con.Close();
            cb.DataSource = ds.Tables[0];
            cb.DisplayMember = "MaTuyen";
            return true;
        }
        public DataTable getAllChuyen()
        {
            string sql = "Select ID, MaTuyen, MaChuyen, ThoiGianKhoiHanh, TenLoaiChuyen, PhuongTien, SoLuongVeMax, GiaVe FROM ChuyenDuLich inner join LoaiChuyen on ChuyenDuLich.MaLoaiChuyen = LoaiChuyen.MaLoaiChuyen";
            //SqlConnection con = dc.getConnect();
            //da = new SqlDataAdapter(sql, con);
            //con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            //con.Close();
            return dt;
        }
        public bool InsertChuyen(tblChuyen route)
        {
            string sql = "Insert into ChuyenDuLich(MaTuyen, MaChuyen, ThoiGianKhoiHanh, MaLoaiChuyen,PhuongTien,SoLuongVeMax, GiaVe) values(@MaTuyen, @MaChuyen, @ThoiGianKhoiHanh, @MaLoaiChuyen,@PhuongTien,@SoLuongVeMax,@GiaVe)";
            SqlConnection con = null;// = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaTuyen", SqlDbType.NVarChar).Value = route.MaTuyen;
                cmd.Parameters.Add("@MaChuyen", SqlDbType.NVarChar).Value = route.MaChuyen;
                cmd.Parameters.Add("@ThoiGianKhoiHanh", SqlDbType.DateTime).Value = route.ThoiGianKhoiHanh;
                cmd.Parameters.Add("@MaLoaiChuyen", SqlDbType.NVarChar).Value = route.MaLoaiChuyen;
                cmd.Parameters.Add("@PhuongTien", SqlDbType.NVarChar).Value = route.PhuongTien;
                cmd.Parameters.Add("@SoLuongVeMax", SqlDbType.Int).Value = route.SoLuongVeMax;
                cmd.Parameters.Add("GiaVe", SqlDbType.Float).Value = route.GiaVe;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateChuyen(tblChuyen route)
        {
            string sql = "Update ChuyenDuLich set MaTuyen=@MaTuyen,MaChuyen=@MaChuyen, ThoiGianKhoiHanh=@ThoiGianKhoiHanh, MaLoaiChuyen=@MaLoaiChuyen,PhuongTien=@PhuongTien,SoLuongVeMax=@SoLuongVeMax,GiaVe=@GiaVe where ID=@ID";
            SqlConnection con = null;// dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = route.identify;
                cmd.Parameters.Add("@MaTuyen", SqlDbType.NVarChar).Value = route.MaTuyen;
                cmd.Parameters.Add("@MaChuyen", SqlDbType.NVarChar).Value = route.MaChuyen;
                cmd.Parameters.Add("@ThoiGianKhoiHanh", SqlDbType.DateTime).Value = route.ThoiGianKhoiHanh;
                cmd.Parameters.Add("@MaLoaiChuyen", SqlDbType.NVarChar).Value = route.MaLoaiChuyen;
                cmd.Parameters.Add("@PhuongTien", SqlDbType.NVarChar).Value = route.PhuongTien;
                cmd.Parameters.Add("@SoLuongVeMax", SqlDbType.Int).Value = route.SoLuongVeMax;
                cmd.Parameters.Add("GiaVe", SqlDbType.Float).Value = route.GiaVe;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteChuyen(tblChuyen route)
        {
            string sql = "Delete ChuyenDuLich where ID=@ID";
            SqlConnection con = null;// dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = route.identify;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable FindChuyen(string route)
        {
            string sql = "Select ID, MaTuyen, MaChuyen, ThoiGianKhoiHanh, TenLoaiChuyen, PhuongTien, SoLuongVeMax, GiaVe FROM ChuyenDuLich inner join LoaiChuyen on ChuyenDuLich.MaLoaiChuyen = LoaiChuyen.MaLoaiChuyen where MaChuyen like N'%" + route + "%'OR MaTuyen like N'%" + route + "%'";
            SqlConnection con = null;//dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
