using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tour
{
    public partial class CSDLPhieuDatCho : Form
    {

        ticketDAL tkDAL = new ticketDAL();
        CustomerDAL cusDAL = new CustomerDAL();
        ReservationDAL resDAL = new ReservationDAL();
        DataConnection dc;
        SqlDataAdapter adapter;
        void Clear()
        {
            tbName.Text=tbAddress.Text = tbID.Text = tbICN.Text = tbphone.Text = tbAddress.Text = "";
            rdbDomestic.Checked = rdbFemale.Checked = rdbMale.Checked = rdbForeign.Checked = false;
        }
        public CSDLPhieuDatCho()
        {
            dc = new DataConnection();
            InitializeComponent();
            tkDAL = new ticketDAL();
            tbSearchTicket.ForeColor = Color.LightGray;
            tbSearchTicket.Text = "Enter Tour ID to search";
            this.tbSearchTicket.Leave += new System.EventHandler(this.textBox1_Leave);
            this.tbSearchTicket.Enter += new System.EventHandler(this.textBox1_Enter);
            tbSearchResID.ForeColor = Color.LightGray;
            tbSearchResID.Text = "Enter Tour ID to search";
            this.tbSearchResID.Leave += new System.EventHandler(this.textBox2_Leave);
            this.tbSearchResID.Enter += new System.EventHandler(this.textBox2_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (tbSearchTicket.Text == "")
            {
                tbSearchTicket.ForeColor = Color.LightGray;
                tbSearchTicket.Text = "Enter Tour ID to search";
                ShowTicket();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (tbSearchTicket.Text == "Enter Tour ID to search")
            {
                tbSearchTicket.Text = "";
                tbSearchTicket.ForeColor = Color.Black;
                ShowTicket();
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (tbSearchResID.Text == "")
            {
                tbSearchResID.ForeColor = Color.LightGray;
                tbSearchResID.Text = "Enter Tour ID to search";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (tbSearchResID.Text == "Enter Tour ID to search")
            {
                tbSearchResID.Text = "";
                tbSearchResID.ForeColor = Color.Black;
            }
        }
        public void ShowTicket()
        {
            string sql = "SELECT DuKhach.MaDuKhach, HanPassport, HanVisa, PhieuDatCho.MaChuyen, TenLoaiTuyen, TenLoaiChuyen, LePhiHoanTra, TienHoanTra, MaVe, Ve.MaPhieu, HoTen, DiaChi, SDT, GioiTinh, TenLoaiKhach, CMND_Passport, Ve.GiaVe FROM(((((((Ve INNER JOIN DuKhach ON Ve.MaDuKhach = DuKhach.MaDuKhach) INNER JOIN LoaiKhach ON DuKhach.MaLoaiKhach = LoaiKhach.MaLoaiKhach)Inner Join PhieuDatCho on PhieuDatCho.MaPhieu = Ve.MaPhieu) INNER JOIN ChuyenDuLich on PhieuDatCho.MaChuyen = ChuyenDuLich.MaChuyen) INNER JOIN Loaichuyen on ChuyenDuLich.MaLoaiChuyen = Loaichuyen.MaLoaiChuyen) INNER JOIN Tuyen on ChuyenDuLich.MaTuyen = Tuyen.MaTuyen)INNER JOIN LoaiTuyen on Tuyen.MaLoaiTuyen = LoaiTuyen.MaLoaiTuyen)";
            SqlConnection con = dc.getConnect();
            adapter = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dgvQuanLy.DataSource = dt;
        }

        public void ShowTicketv2()
        {
            string sql = "Select Ve.MaPhieu, HoTen from (((Ve INNER JOIN DuKhach ON Ve.MaDuKhach = DuKhach.MaDuKhach) INNER JOIN LoaiKhach ON DuKhach.MaLoaiKhach = LoaiKhach.MaLoaiKhach)Inner Join PhieuDatCho on PhieuDatCho.MaPhieu = Ve.MaPhieu)";
            SqlConnection con = dc.getConnect();
            adapter = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }


        int TicketID, CustomerID, ReservationID, CostTicket;
        string NameOfRouteType, NameOfTourType, TourID;

        private void dgvQuanLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            String gender, tourist;
            if (index >= 0)
            {
                CustomerID = Int32.Parse(dgvQuanLy.Rows[index].Cells["MaDuKhach"].Value.ToString());
                TicketID = Int32.Parse(dgvQuanLy.Rows[index].Cells["MaVe"].Value.ToString());
                ReservationID = Int32.Parse(dgvQuanLy.Rows[index].Cells["MaPhieuDatCho"].Value.ToString());
                TourID = dgvQuanLy.Rows[index].Cells["MaChuyen"].Value.ToString();
                NameOfTourType = dgvQuanLy.Rows[index].Cells["TenLoaiChuyen"].Value.ToString();
                NameOfRouteType = dgvQuanLy.Rows[index].Cells["TenloaiTuyen"].Value.ToString();
                CostTicket = Int32.Parse(dgvQuanLy.Rows[index].Cells["GiaVe"].Value.ToString());

                tbID.Text = dgvQuanLy.Rows[index].Cells["MaChuyen"].Value.ToString();
                tbName.Text = dgvQuanLy.Rows[index].Cells["HoTen"].Value.ToString();
                tbAddress.Text = dgvQuanLy.Rows[index].Cells["DiaChi"].Value.ToString();
                tbphone.Text = dgvQuanLy.Rows[index].Cells["SDT"].Value.ToString();
                tbICN.Text = dgvQuanLy.Rows[index].Cells["CMND_Passport"].Value.ToString();
                gender = dgvQuanLy.Rows[index].Cells["GioiTinh"].Value.ToString();
                if (gender == "Male")
                {
                    rdbMale.Checked = true;
                }
                else if (gender == "Female")
                {
                    rdbFemale.Checked = true;
                }
                tourist = dgvQuanLy.Rows[index].Cells["TenLoaiKhach"].Value.ToString();
                if (tourist == "Foreign")
                {
                    rdbForeign.Checked = true;
                }
                else if (tourist == "Domestic")
                {
                    rdbDomestic.Checked = true;
                }
            }
        }
        private void CSDLPhieuDatCho_Load(object sender, EventArgs e)
        {
            ShowTicket();
            tientong();
        }
        void tientong()
        {
            int sum = 0;
            for (int i = 0; i < dgvQuanLy.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvQuanLy.Rows[i].Cells["GiaVe"].Value);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Customer cus = new Customer();

                cus.MaDuKhach = CustomerID;
                cus.HoTen = tbName.Text;
                cus.DiaChi = tbAddress.Text;
                cus.SDT = tbphone.Text;
                cus.GioiTinh = "Male";
                if (rdbDomestic.Checked == true)
                {
                    cus.MaLoaiKhach = "CUS001";
                }
                else cus.MaLoaiKhach = "CUS002";

                if (rdbFemale.Checked == true)
                {
                    cus.GioiTinh = "Female";
                }

                cus.CMND_Passport = tbICN.Text;
                cus.HanPassport = dtpPassport.Value;
                cus.HanVisa = dtpVisa.Value;

                if (cusDAL.Update(cus))
                {
                    ShowTicket();
                }
                else MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                Clear();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbSearchTicket.Text;
            if (!string.IsNullOrEmpty(value))
            {
                string sql = "SELECT DuKhach.MaDuKhach, HanPassport, HanVisa, PhieuDatCho.MaChuyen, TenLoaiTuyen, TenLoaiChuyen, LePhiHoanTra, TienHoanTra, MaVe, Ve.MaPhieu, HoTen, DiaChi, SDT, GioiTinh, TenLoaiKhach, CMND_Passport, Ve.GiaVe FROM(((((((Ve INNER JOIN DuKhach ON Ve.MaDuKhach = DuKhach.MaDuKhach) INNER JOIN LoaiKhach ON DuKhach.MaLoaiKhach = LoaiKhach.MaLoaiKhach)Inner Join PhieuDatCho on PhieuDatCho.MaPhieu = Ve.MaPhieu) INNER JOIN ChuyenDuLich on PhieuDatCho.MaChuyen = ChuyenDuLich.MaChuyen) INNER JOIN Loaichuyen on ChuyenDuLich.MaLoaiChuyen = Loaichuyen.MaLoaiChuyen) INNER JOIN Tuyen on ChuyenDuLich.MaTuyen = Tuyen.MaTuyen)INNER JOIN LoaiTuyen on Tuyen.MaLoaiTuyen = LoaiTuyen.MaLoaiTuyen)  where PhieuDatCho.MaChuyen like N'%" + value + "%'";
                SqlConnection con = dc.getConnect();
                adapter = new SqlDataAdapter(sql, con);
                con.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                dgvQuanLy.DataSource = dt;
            }
            else { ShowTicket(); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string value = tbSearchResID.Text;
            if (!string.IsNullOrEmpty(value))
            {
                string sql = "Select PhieuDatCho.MaChuyen, Ve.MaPhieu, HoTen from (((Ve INNER JOIN DuKhach ON Ve.MaDuKhach = DuKhach.MaDuKhach) INNER JOIN LoaiKhach ON DuKhach.MaLoaiKhach = LoaiKhach.MaLoaiKhach)Inner Join PhieuDatCho on PhieuDatCho.MaPhieu = Ve.MaPhieu)  where MaChuyen like N'%" + value + "%'";
                SqlConnection con = dc.getConnect();
                adapter = new SqlDataAdapter(sql, con);
                con.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
            }
            else { ShowTicketv2(); }
        }

        public bool CheckData()
        {
            DateTime date = GetTime(tbID.Text);

            if (String.IsNullOrEmpty(tbName.Text) || String.IsNullOrEmpty(tbphone.Text) || String.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show("Please fill in all the information", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (rdbForeign.Checked == true && dtpPassport.Value.Date <= date.Date)
            {
                MessageBox.Show("Passport expire error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (rdbForeign.Checked == true && dtpVisa.Value.Date <= date.Date)
            {
                MessageBox.Show("Visa expire error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void tbphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rdbForeign_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDomestic.Checked)
            {
                panelTime.Visible = false;
            }
            else
            {
                panelTime.Visible = true;
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSearchResID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSearchTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbName_Enter(object sender, EventArgs e)
        {
            ShowTicket();
        }

        private void tbAddress_Enter(object sender, EventArgs e)
        {
            ShowTicket();
        }

        private void tbphone_Enter(object sender, EventArgs e)
        {
            ShowTicket();
        }

        private void btnTraVe_Click(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            DateTime date = GetTime(TourID);
            TimeSpan interval = date - current;
            tblTicket tk = new tblTicket();
            Customer cus = new Customer();
            Reservation res = new Reservation();
   

            float result;
            float costA = 1;
            int costB = 0;
            tk.MaVe = TicketID;
            cus.MaDuKhach = CustomerID;
            res.MaPhieu = ReservationID;

            if (NameOfRouteType == "National" && interval.Hours < 4)
            {
                costB = getLePhiHoanTra(NameOfRouteType);               
            }
            else if (NameOfRouteType == "International" && interval.Days < 3)
            {
                costB = getLePhiHoanTra(NameOfRouteType);               
            }
            if (NameOfTourType == "Regular")
            {
                costA = getTienHoantra(NameOfTourType);
            }
            else if (NameOfTourType == "Promotional")
            {
                costA = getTienHoantra(NameOfTourType);
            }

            result = (CostTicket * costA) - costB;
            if (result > 0)
            {
                MessageBox.Show("You get paid " + result + " for ticket refund ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result < 0)
            {
                MessageBox.Show("You have to pay extra " + result * (-1) + " for ticket refund ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Clear();

            //if (tkDAL.Delete(tk) && cusDAL.Delete(cus) && resDAL.Delete(res))
            //{
            //    ShowTicket();
            //}
            //else MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblTicket tk = new tblTicket();
                Customer cus = new Customer();
                Reservation res = new Reservation();
                tk.MaVe = TicketID;
                cus.MaDuKhach = CustomerID;
                res.MaPhieu = ReservationID;

                if (tkDAL.Delete(tk) && cusDAL.Delete(cus) && resDAL.Delete(res))
                {
                    ShowTicket();
                }
                else MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tientong();
                Clear();
            }
        }
        public float getTienHoantra(string TenLoaiChuyen)
        {
            float cost = 0;
            string sql = "SELECT TienHoanTra FROM LoaiChuyen WHERE TenLoaiChuyen = @TenLoaiChuyen";
            SqlConnection con = dc.getConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@TenLoaiChuyen", TenLoaiChuyen);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                cost = float.Parse(da.GetValue(0).ToString());
            }
            return cost;
        }

        public int getLePhiHoanTra(string TenLoaiTuyen)
        {
            int cost = 0;
            string sql = "SELECT LePhiHoanTra FROM LoaiTuyen WHERE TenLoaiTuyen = @TenLoaiTuyen";
            SqlConnection con = dc.getConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@TenLoaiTuyen", TenLoaiTuyen);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                cost = Int32.Parse( da.GetValue(0).ToString());             
            }
            return cost;
        }

        public DateTime GetTime(string MaChuyen)
        {
            DateTime date = new DateTime();
            string sql = "SELECT ThoiGianKhoiHanh FROM ChuyenDuLich WHERE MaChuyen = @MaChuyen";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaChuyen", MaChuyen);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    date = da.GetDateTime(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return date;
        }
    }
}