using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Tour
{
    public partial class ChangePass : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-CI36P6F;Initial Catalog=TourManagement;Integrated Security=True";
        string email = forgotpass.to;
        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        public ChangePass()
        {
            InitializeComponent();
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            if (newpasstxb.Text == confirmtxb.Text && newpasstxb.Text != "")
            {
                SqlConnection sqlc = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand("UPDATE [dbo].[UserID] SET [Password] ='" + /*Encrypt(*/newpasstxb.Text/*)*/ + "' WHERE Email='" + email + "' ", sqlc);
                sqlc.Open();
                sqlCmd.ExecuteNonQuery();
                sqlc.Close();
                MessageBox.Show("Reset password success!!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password does not match!!!");
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
