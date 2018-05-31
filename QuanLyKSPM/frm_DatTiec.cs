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
    public partial class frm_DatTiec : Form
    {
        public frm_DatTiec()
        {
            InitializeComponent();
        }
        int Tongtien;
        string chuoi = @"Data Source=PC\SQLEXPRESS;Initial Catalog=qlks;Integrated Security=True";
        SqlConnection strconn = new SqlConnection();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selection s1 = new Selection();
            s1.ShowDialog();
            this.Close();
        }

        private void btn_XemDanhSachDatTiec_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlht = "select * from HOADONDATTIEC";
            SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
            DataTable mydt = new DataTable();
            mydata.Fill(mydt);
            dataGridView1.DataSource = mydt;
            strconn.Close();
        }
        string ngaydat;
        private void btn_DatTiec_Click(object sender, EventArgs e)
        {
            if (lb_tinhtrangphong.Text != "Đã có người đặt")
            {
                strconn = new SqlConnection(chuoi);
                strconn.Open();
                string phanloai = "Thue Phong";
                string sqlThemKH = "insert into KHACHHANG values (N'" + txt_KH_MaKH.Text + "', N'" + txt_KH_TenKH.Text + "',N'" + txt_KH_SDT.Text + "',N'" + txt_KH_CMND.Text + "',N'" + txt_KH_Passport.Text + "',N'" + phanloai + "')";
                string sqlDatTiec = "insert into CHITIETHOADONDATTIEC values (N'" + MACTHDT.ToString() + "', N'" + txt_CTHDDT_SL.Text + "',N'" + lb_TongTienBan.Text + "',N'" + DateTime.Now.ToShortDateString() + "',N'" + dateTimePicker1.Value.ToShortDateString()+ "')";
                string sqlHoaDonDT = "insert into HOADONDATTIEC values (N'" + MAHDDT.ToString() + "', N'" + txt_KH_MaKH.Text + "',N'" + MACTHDT.ToString() + "',N'" + dateTimePicker1.Value.ToShortDateString() + "',N'" + lb_TongTien.Text + "')";
                SqlCommand cmd1 = new SqlCommand(sqlThemKH, strconn);
                SqlCommand cmd2 = new SqlCommand(sqlDatTiec, strconn);
                SqlCommand cmd3 = new SqlCommand(sqlHoaDonDT, strconn);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Đặt thành công");
            }
            else
                MessageBox.Show("Có người đặt r");
        }
        int MACTHDT;
        int MAHDDT;
        private void frm_DatTiec_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
           MACTHDT= rnd.Next(1, 100000);
            MAHDDT = MACTHDT;
            Random rnd2 = new Random();
            txt_KH_MaKH.Text = rnd2.Next(1, 1000000).ToString();
            txt_DT_MaKH.Text = txt_KH_MaKH.Text;
            txt_GiaTienBan.Text = "4000000";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlxoa = "delete from CHITIETMONAN";
            SqlCommand cmd1 = new SqlCommand(sqlxoa, strconn);
            cmd1.ExecuteNonQuery();
            
        }

        private void btn_XemDSMonAnn_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlht = "select * from MONAN";
            SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
            DataTable mydt = new DataTable();
            mydata.Fill(mydt);
            dataGridView2.DataSource = mydt;
            strconn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MA_MaMA.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txt_MaMA__TenMA.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_GiaTienMA.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_CTMA_SL.Text = "0";
        }

        private void txt_CTMA_SL_TextChanged(object sender, EventArgs e)
        {
            int tongtienma = int.Parse(txt_CTMA_SL.Text) * int.Parse(txt_GiaTienMA.Text);
            lb_TongTienMA.Text = tongtienma.ToString();

        }

        private void btn_DSMADachon_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlht = "SELECT CHITIETMONAN.MAMA,CHITIETMONAN.TENMA,CHITIETMONAN.SOLUONG,MONAN.Gia,CHITIETMONAN.TONGTIEN FROM CHITIETMONAN INNER JOIN MONAN ON MONAN.MaMA = CHITIETMONAN.MAMA";
            SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
            DataTable mydt = new DataTable();
            mydata.Fill(mydt);
            dataGridView3.DataSource = mydt;
            strconn.Close();
            int a = 0;
            foreach (DataGridViewRow r in dataGridView3.Rows)
            {
                {
                    a += Convert.ToInt32(r.Cells[4].Value);
                }
            }
            lb_TongTienMA.Text = a.ToString();
        }

        private void btn_Luumonan_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlTHEMMON = "insert into CHITIETMONAN values (N'" + txt_MA_MaMA.Text + "', N'" + txt_MaMA__TenMA.Text + "',N'" + txt_CTMA_SL.Text + "',N'" + lb_TongTienMA.Text + "')";
            SqlCommand cmd1 = new SqlCommand(sqlTHEMMON, strconn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Đã thêm món");



        }

        private void Xoá_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlxoama = "delete from chitietmonan where MAMA='" + txt_MA_MaMA.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqlxoama, strconn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Đã xoá món");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MA_MaMA.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txt_MaMA__TenMA.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            txt_CTMA_SL.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            txt_GiaTienMA.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
        }

        private void txt_CTHDDT_SL_TextChanged(object sender, EventArgs e)
        {
            int tongtienban;
            tongtienban = int.Parse(txt_CTHDDT_SL.Text) * int.Parse(txt_GiaTienBan.Text);
            lb_TongTienBan.Text = tongtienban.ToString();
        }

        private void lb_TongTienBan_TextChanged(object sender, EventArgs e)
        {
            Tongtien = int.Parse(lb_TongTienBan.Text) + int.Parse(lb_TongTienMA.Text);
            lb_TongTien.Text = Tongtien.ToString();
        }

        private void lb_TongTienMA_TextChanged(object sender, EventArgs e)
        {
            Tongtien = int.Parse(lb_TongTienBan.Text) + int.Parse(lb_TongTienMA.Text);
            lb_TongTien.Text = Tongtien.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ngaydat = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_Kiemtra_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

              
                if (dateTimePicker1.Value.ToShortDateString() == dataGridView1.Rows[i].Cells[3].Value.ToString())
                {
                    lb_tinhtrangphong.Text = "Đã có người đặt";
                    lb_tinhtrangphong.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lb_tinhtrangphong.Text = "Chưa có người đặt";
                    lb_tinhtrangphong.ForeColor = System.Drawing.Color.Red;
                }

            }
        }

        
    }
}
