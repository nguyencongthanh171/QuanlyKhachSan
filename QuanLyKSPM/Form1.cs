using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace QuanLyKSPM
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=qlks;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Admin where Tendn='" + txt_tdn.Text + "' and Matkhau='" + txt_pass.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
              
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                Selection s1 = new Selection();
                s1.ShowDialog();
                this.Close();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
