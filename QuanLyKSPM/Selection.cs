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
    public partial class Selection : Form
    {
        int pw;
        bool hided;
        public Selection()
        {
            InitializeComponent();
            pw = panel1.Height;
            hided = false;
        }

       string chuoi = @"Data Source=PC\SQLEXPRESS;Initial Catalog=qlks;Integrated Security=True";
        SqlConnection strconn = new SqlConnection();
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text.Contains( "Hiển thị danh sách Phòng"))
            {
                strconn = new SqlConnection(chuoi);
                strconn.Open();
                string sqlht = "select * from Phong";
                SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
                DataTable mydt = new DataTable();
                mydata.Fill(mydt);
                dataGridView1.DataSource = mydt;
                button5.Text = "Đóng danh sách phòng";

                dataGridView1.Visible = true;
                strconn.Close();
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                button5.Text = "Hiển thị danh sách Phòng";
                dataGridView1.Visible = false;
               
               

            }
            
        }

        private void btn_Datphong_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DatPhong f1 = new frm_DatPhong();
        
            f1.ShowDialog();
            this.Close();
        }

        private void btn_TraPhong_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Traphong f1 = new frm_Traphong();
         
            f1.ShowDialog();
            this.Close();
        }

        private void btn_DatTiec_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DatTiec f1 = new frm_DatTiec();
         
     
            f1.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                    strconn = new SqlConnection(chuoi);
                    strconn.Open();
                    string sqlht = "select * from Phong where LoaiPhong like N'" + textBox1.Text + "%'";
                    SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
                    DataTable mydt = new DataTable();
                    mydata.Fill(mydt);
                    dataGridView1.DataSource = mydt;
                    strconn.Close();
               
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            try {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn backup dữ liệu ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    strconn = new SqlConnection(chuoi);
                    strconn.Open();
                    string backup = @"BACKUP DATABASE qlks TO DISK = 'C:\Backup\qlks.BAK'";
                    SqlCommand cmd1 = new SqlCommand(backup, strconn);
                    cmd1.ExecuteNonQuery();

                    lb_Thongbao.Text = "Backup thành công";
                    lb_Thongbao.ForeColor = System.Drawing.Color.Red;
                    lb_Thongbao.Visible = true;
                    int i = 0;
                }
            }
            catch
            {
                lb_Thongbao.Text = "Backup lỗi, vui lòng xem lại thư mục backup";
                lb_Thongbao.ForeColor = System.Drawing.Color.Red;
                lb_Thongbao.Visible = true;
            }
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {

            this.Hide();
            frm_Baocao f1 = new frm_Baocao();
            

            f1.ShowDialog();
            this.Close();
        }

        private void Selection_Load(object sender, EventArgs e)
        {
            lb_Thongbao.Visible = false;
            timer2.Start();
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
            dataGridView1.Visible = false;
         
        }

        private void btn_Khoiphucdulieu_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn khôi phục dữ liệu ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result ==DialogResult.Yes)
                {
                    strconn = new SqlConnection(chuoi);
                    strconn.Open();
                    string backup = @"RESTORE DATABASE qlks FROM DISK = 'C:\Backup\qlks.BAK' With Replace ";
                    string closeconn = "Alter database qlks set OFFLINE with rollback immediate";
                    string openconn = "Alter database qlks set online with rollback immediate";
                    SqlCommand cmd0 = new SqlCommand(closeconn, strconn);
                    SqlCommand cmd1 = new SqlCommand(backup, strconn);
                    SqlCommand cmd2 = new SqlCommand(openconn, strconn);
                    cmd0.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    lb_Thongbao.Text = "Khôi phục thành công";
                    lb_Thongbao.ForeColor = System.Drawing.Color.Red;
                    lb_Thongbao.Visible = true;
                }
                
            }
            catch
            {
                lb_Thongbao.Text = "Khôi phục lỗi, vui lòng xem lại thư mục backup";
                lb_Thongbao.ForeColor = System.Drawing.Color.Red;
                lb_Thongbao.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Login f1 = new frm_Login();
         

            f1.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hided)
            {
                panel1.Height = pw;
               
                if (panel1.Height >=0)
                {
                    timer1.Stop();
                    hided = false;
                    this.Refresh();
                }
               
            }
            else
            {
                panel1.Height = panel1.Height - 20;
               
                if(panel1.Height<=0)
                {
                    timer1.Stop();
                    hided = true;
                    this.Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hided)
            {
                button1.Text = "Ẩn chức năng";
                dataGridView1.Location = new Point(-2, 274);
                dataGridView1.Height -= 100;
            }
            else { button1.Text = "Hiện chức năng";
                dataGridView1.Location = new Point(-2, 194);
                dataGridView1.Height += 100;
            }
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            timer2.Start();
        }
    }
}
