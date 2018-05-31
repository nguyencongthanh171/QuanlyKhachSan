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
    public partial class frm_DatPhong : Form
    {
        public frm_DatPhong()
        {
            InitializeComponent();
           
           
        }
        string chuoi = @"Data Source=PC\SQLEXPRESS;Initial Catalog=qlks;Integrated Security=True";
        SqlConnection strconn = new SqlConnection();
        int MaKH;
        int SPTP;
        int SPDT;
        private void btn_DatPhong_Click(object sender, EventArgs e)
        {
            string phanloai = "Thue Phong";
            string tinthrang = "Đã Thuê";
            strconn = new SqlConnection(chuoi);
            strconn.Open();

            if (txt_TinhTrangphong.Text == "Ðã Thuê   ")
                MessageBox.Show("Phòng đã thuê, vui lòng chọn phòng khác");

            else
            {

                string sqlThemKH = "insert into KHACHHANG values (N'" + txt_KH_MaKH.Text + "', N'" + txt_KH_TenKH.Text + "',N'" + txt_KH_SDT.Text + "',N'" + txt_KH_CMND.Text + "',N'" + txt_KH_Passport.Text + "',N'" + phanloai + "')";
                string sqlDatPhong = "insert into DATPHONG values (N'" + txt_DP_SDP.Text + "', N'" + txt_DP_MaKH.Text + "',N'" + txt_DP_NgayDat.Text + "',N'" + txt_DP_TienCoc.Text + "')";
                string sqlThuePhong = "insert into THUEPHONG values (N'" + txt_TP_STP.Text + "', N'" + txt_DP_SDP.Text + "',N'" + txt_KH_MaKH.Text + "',N'" + txt_TP_MaPhong.Text + "',N'" + dateTimePicker1.Value.ToShortDateString() + "',N'" + dateTimePicker2.Value.ToShortDateString() + "')";
                string sqlDoiTrangThai = "update Phong set Tinhtrang='" + tinthrang + "' where MaPhong = '" + txt_TP_MaPhong.Text + "'";
                SqlCommand cmd1 = new SqlCommand(sqlThemKH, strconn);
                SqlCommand cmd2 = new SqlCommand(sqlDatPhong, strconn);
                SqlCommand cmd3 = new SqlCommand(sqlThuePhong, strconn);
                SqlCommand cmd4 = new SqlCommand(sqlDoiTrangThai, strconn);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();

            }



        }

        private void frm_DatPhong_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            MaKH = rnd.Next(2, 1000000);
            txt_KH_MaKH.Text = MaKH.ToString();
            txt_DP_MaKH.Text = MaKH.ToString();
            txt_DP_TienCoc.Text = "500000";

            Random rnd1 = new Random();
            SPDT = rnd1.Next(1, 100000000);
            txt_DP_SDP.Text = SPDT.ToString();
            txt_TP_STP.Text = SPDT.ToString();
            lbl_Tien.Text = txt_DP_TienCoc.Text;
            txt_DP_NgayDat.Text = DateTime.Now.ToShortDateString();
          
        }

        public void HienThi()

        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlht = "select * from Phong";
            SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
            DataTable mydt = new DataTable();
            mydata.Fill(mydt);
            dataGridView1.DataSource = mydt;
            strconn.Close();
        }
        private void btn_XemDanhSachPhong_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btn_ChoThue_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlht = "select * from ThuePhong";
            SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
            DataTable mydt = new DataTable();
            mydata.Fill(mydt);
            dataGridView2.DataSource = mydt;
            strconn.Close();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_DP_TienCoc_TextChanged(object sender, EventArgs e)
        {
            if (txt_DP_TienCoc.Text != "")
            {
                lbl_Tien.Text = txt_DP_TienCoc.Text;
                lbl_Tien.Visible = true;
            }
        }

        private void btn_Quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selection s1 = new Selection();
            s1.ShowDialog();
            this.Close();
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_TinhTrangphong.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_TP_MaPhong.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
         
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {



                if (dateTimePicker1.Value.ToShortDateString() == dataGridView2.Rows[i].Cells[4].Value.ToString() || dateTimePicker1.Value.ToShortDateString() == dataGridView2.Rows[i].Cells[5].Value.ToString())
                {
                    MessageBox.Show("Đã có người đặt vào ngày này");
                    btn_DatPhong.Enabled = false;
                }
                else
                {
                    btn_DatPhong.Enabled = true;
                }
              
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (dateTimePicker2.Value.ToShortDateString() == dataGridView2.Rows[i].Cells[5].Value.ToString() || dateTimePicker2.Value.ToShortDateString() == dataGridView2.Rows[i].Cells[4].Value.ToString())
                {
                    MessageBox.Show("Đã có người đặt vào ngày này");
                    btn_DatPhong.Enabled = false;
                }
                else
                {
                    btn_DatPhong.Enabled = true;
                }
            }
        }
    }
}
