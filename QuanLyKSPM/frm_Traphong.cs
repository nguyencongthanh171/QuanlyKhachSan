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
    public partial class frm_Traphong : Form
    {
        public frm_Traphong()
        {
            InitializeComponent();
            
        }
        int MACTDV1;
        int MACTDV2;
        int MACTDV3;
        int MAHDDV1;
        int MAHDDV2;
        int MAHDDV3;
        int Tongtien;
        string chuoi = @"Data Source=PC\SQLEXPRESS;Initial Catalog=qlks;Integrated Security=True";
        SqlConnection strconn = new SqlConnection();
        private void chb_Spa_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Spa.Checked == true)

            {
                Tongtien = (int.Parse(lbl_Tien.Text) + (int.Parse(txt_SpaSl.Text) * 500000));
                lbl_Tien.Text = Tongtien.ToString();
                txt_SpaSl.ReadOnly = true;

            }
            else if (chb_Spa.Checked == false)
            {
                txt_SpaSl.ReadOnly = false;

                Tongtien = int.Parse(lbl_Tien.Text) - (int.Parse(txt_SpaSl.Text) * 500000);
                txt_SpaSl.Text = "0";
                lbl_Tien.Text = Tongtien.ToString();
            }
        }

        private void chb_XongHoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_XongHoi.Checked == true)

            {
                Tongtien = int.Parse(lbl_Tien.Text) + (int.Parse(txt_XHSL.Text) * 200000);
                lbl_Tien.Text = Tongtien.ToString();
                txt_XHSL.ReadOnly = true;

            }
            else if(chb_XongHoi.Checked==false)
            {
                txt_XHSL.ReadOnly = false;

                Tongtien = int.Parse(lbl_Tien.Text) - (int.Parse(txt_XHSL.Text) * 200000);
                txt_XHSL.Text = "0";
                lbl_Tien.Text = Tongtien.ToString();
            }
        }

        private void chb_Tennis_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Tennis.Checked == true)

            {
                Tongtien = int.Parse(lbl_Tien.Text) + (int.Parse(txt_TennisSL.Text) * 100000);
                lbl_Tien.Text = Tongtien.ToString();
                txt_TennisSL.ReadOnly = true;
            }
            else if (chb_Tennis.Checked == false)
            {
                txt_TennisSL.ReadOnly = false;

                Tongtien = int.Parse(lbl_Tien.Text) - (int.Parse(txt_TennisSL.Text) * 100000);
                txt_TennisSL.Text = "0";
                lbl_Tien.Text = Tongtien.ToString();
            }
        }

        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_TP_STP.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txt_DP_SDP.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_DP_MaKH.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txt_TP_MaPhong.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_TP_NgayDenn.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            txt_TP_NgayDi.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            txt_Giaphong.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            txt_LoaiPhong.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txt_DP_TienCoc.Text = "500000";
            int tiensaucoc = int.Parse(txt_Giaphong.Text) - 500000;
            lbl_Tien.Text = tiensaucoc.ToString();
            Random rnd = new Random();
            int MaHd = rnd.Next(1, 100000);
            txt_MaHD.Text = MaHd.ToString();

        }

        private void btn_ChoThue_Click(object sender, EventArgs e)
        {
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlht = "SELECT THUEPHONG.SoPhieuTP, THUEPHONG.SoPhieuDP ,PHONG.MaPhong,THUEPHONG.MaKH,PHONG.TenPhong,PHONG.LoaiPhong,PHONG.GIA,THUEPHONG.Ngayden,THUEPHONG.Ngaydi,PHONG.Tinhtrang FROM PHONG INNER JOIN THUEPHONG ON THUEPHONG.MaPhong = PHONG.MaPhong";
            SqlDataAdapter mydata = new SqlDataAdapter(sqlht, strconn);
            DataTable mydt = new DataTable();
            mydata.Fill(mydt);
            dataGridView2.DataSource = mydt;
            strconn.Close();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            int tongtienspa = int.Parse(txt_SpaSl.Text) * 500000;
            int tongtienxh = int.Parse(txt_XHSL.Text) * 200000;
            int tongtientennis = int.Parse(txt_TennisSL.Text) * 100000;
            string tinthrang = "Trong";
            string maspa = "DV01";
            string maxh = "DV02";
            string matennis = "DV03";
            string LoaiHD = "Đặt Phòng";
            strconn = new SqlConnection(chuoi);
            strconn.Open();
            string sqlDoiTrangThai = "update Phong set Tinhtrang='" + tinthrang + "' where MaPhong = '" + txt_TP_MaPhong.Text + "'";
            string sqlXoaThuePhong = "delete from Thuephong where SoPhieuTP='" + txt_TP_STP.Text + "'";
            string sqlXoaDatPhong = "delete from DatPhong where SoPhieuDP='" + txt_DP_SDP.Text + "'";
            string sqlXoaKhachHang = "delete from KHACHHANG where MaKH='" + txt_DP_MaKH.Text + "'";
            string sqlThemHoaDon = "insert into HoaDonPhong values (N'" + txt_MaHD.Text + "',N'" + txt_DP_MaKH.Text + "',N'" + lbl_Tien.Text + "',N'" + txt_TP_NgayDi.Text + "')";
            string sqlthemspa = "insert into CHITIETHOADONDICHVU values (N'" + MACTDV1.ToString() + "',N'" + maspa + "',N'" + txt_SpaSl.Text + "',N'" + tongtienspa + "')";
            string sqlthemxh = "insert into CHITIETHOADONDICHVU values (N'" + MACTDV2.ToString() + "',N'" + maxh + "',N'" + txt_XHSL.Text + "',N'" + tongtienxh + "')";
            string sqlthemtennis = "insert into CHITIETHOADONDICHVU values (N'" + MACTDV3.ToString() + "',N'" + matennis + "',N'" + txt_TennisSL.Text + "',N'" + tongtientennis + "')";
            string sqlthemspahd= "insert into HOADONDICHVU values (N'" + MAHDDV1.ToString() + "',N'" + txt_DP_MaKH.Text + "',N'" + MACTDV1.ToString() + "',N'" +txt_TP_NgayDi.Text+ "', N'"+tongtienspa+"')";
            string sqlthemxhhd = "insert into HOADONDICHVU values (N'" + MAHDDV2.ToString() + "',N'" + txt_DP_MaKH.Text + "',N'" + MACTDV2.ToString() + "',N'" + txt_TP_NgayDi.Text + "', N'" + tongtienxh + "')";
            string sqlthemteenishd = "insert into HOADONDICHVU values (N'" + MAHDDV3.ToString() + "',N'" + txt_DP_MaKH.Text + "',N'" + MACTDV3.ToString() + "',N'" + txt_TP_NgayDi.Text + "', N'" + tongtientennis + "')";

            SqlCommand cmd4 = new SqlCommand(sqlDoiTrangThai, strconn);
            SqlCommand cmd3 = new SqlCommand(sqlXoaThuePhong, strconn);
            SqlCommand cmd2 = new SqlCommand(sqlXoaDatPhong, strconn);
            SqlCommand cmd1 = new SqlCommand(sqlXoaKhachHang, strconn);
            SqlCommand cmd5 = new SqlCommand(sqlThemHoaDon, strconn);
            SqlCommand cmd6 = new SqlCommand(sqlthemspa, strconn);
            SqlCommand cmd7 = new SqlCommand(sqlthemxh, strconn);
            SqlCommand cmd8 = new SqlCommand(sqlthemtennis, strconn);
            SqlCommand cmd9 = new SqlCommand(sqlthemspahd, strconn);
            SqlCommand cmd10 = new SqlCommand(sqlthemxhhd, strconn);
            SqlCommand cmd11 = new SqlCommand(sqlthemteenishd, strconn);
            cmd5.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            if (chb_Spa.Checked==true)
            {
                cmd6.ExecuteNonQuery();
                cmd9.ExecuteNonQuery();
            }
            if (chb_XongHoi.Checked == true)
            {
                cmd7.ExecuteNonQuery();
                cmd10.ExecuteNonQuery();
            }
            if (chb_Tennis.Checked == true)
            {
                cmd8.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
            }
         

            MessageBox.Show("Đã trả phòng thành công");
        }

        private void txt_TP_MaPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_Traphong_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int MaHd = rnd.Next(1, 100000);
            txt_MaHD.Text = MaHd.ToString();
            txt_SpaSl.Text = "0";
            txt_XHSL.Text = "0";
            txt_TennisSL.Text = "0";
          
         
          
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selection s1 = new Selection();
            s1.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Tien_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_LoaiPhong_TextChanged(object sender, EventArgs e)
        {
            if (txt_LoaiPhong.Text == "Hoàng Gia")
            {
                Tongtien = int.Parse(txt_Giaphong.Text) - 500000;
                chb_Spa.Enabled = false;
                chb_Tennis.Enabled = false;
                chb_XongHoi.Enabled = false;
                txt_SpaSl.Enabled = false;
                txt_TennisSL.Enabled = false;
                txt_XHSL.Enabled = false;
            }
            else
            {
                chb_Spa.Enabled = true;
      
                chb_Tennis.Enabled = true;
                chb_XongHoi.Enabled = true;
                txt_SpaSl.Enabled = true;
                txt_TennisSL.Enabled = true;
                txt_XHSL.Enabled = true;
            }
        }

        private void txt_SpaSl_TextChanged(object sender, EventArgs e)
        {
            Random rnd2 = new Random();
            MACTDV1 = rnd2.Next(1, 1000000);
            MAHDDV1 = rnd2.Next(1, 1000000);
        }

        private void txt_XHSL_TextChanged(object sender, EventArgs e)
        {
            Random rnd3 = new Random();
            MACTDV2 = rnd3.Next(1, 1000000);
            MAHDDV2 = rnd3.Next(1, 1000000);
        }

        private void txt_TennisSL_TextChanged(object sender, EventArgs e)
        {
            Random rnd4 = new Random();
            MACTDV3 = rnd4.Next(1, 1000000);
            MAHDDV3 = rnd4.Next(1, 1000000);
        }
    }
}
