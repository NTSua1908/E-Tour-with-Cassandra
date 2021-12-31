using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Tour
{
    public partial class StaffProfile : Form
    {
        public StaffProfile()
        {
            InitializeComponent();
        }

        private void StaffProfile_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                txbGmail.Text = Properties.Settings.Default.UserName;
            }
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CI36P6F;Initial Catalog=TourManagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Ho,Ten,SĐT from UserID where Email=@Email", con);
            cmd.Parameters.Add("@Email", txbGmail.Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                txbHo.Text = da.GetValue(0).ToString();
                txbTen.Text = da.GetValue(1).ToString();
                txbSDT.Text = da.GetValue(2).ToString();
            }
            con.Close();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
