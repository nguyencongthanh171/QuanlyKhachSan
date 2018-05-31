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
using System.Web;
using Microsoft.Reporting.WinForms;
namespace QuanLyKSPM
{
    public partial class frm_Baocao : Form
    {
        public frm_Baocao()
        {
            InitializeComponent();
        }
        string chuoi = @"Data Source=PC\SQLEXPRESS;Initial Catalog=qlks;Integrated Security=True";
        SqlConnection strconn = new SqlConnection();
        private void btn_BaoCaoDatPhong_Click(object sender, EventArgs e)
        {



            if (comboBox2.SelectedItem.ToString() == "Phòng")
            {
               

                reportViewer1.Reset();
                ReportDataSource RDS = new ReportDataSource("BaoCaoHDP");
                this.reportViewer1.LocalReport.DataSources.Add(RDS);
                RDS.Value = this.HOADONPHONGBindingSource;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKSPM.Report1.rdlc";
                this.HOADONPHONGTableAdapter.Fill(this.BaoCaoHDP.HOADONPHONG, comboBox1.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
            }
            if(comboBox2.SelectedItem.ToString()== "Đặt Tiệc")
            {
                reportViewer1.Reset();
                ReportDataSource RDS = new ReportDataSource("BaoCaoDatTiec");
                this.reportViewer1.LocalReport.DataSources.Add(RDS);
                RDS.Value = this.HOADONDATTIECBindingSource;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKSPM.Report2.rdlc";
                this.HOADONDATTIECTableAdapter.Fill(this.BaoCaoDatTiec.HOADONDATTIEC, comboBox1.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
            }
            if(comboBox2.SelectedItem.ToString() == "Dịch vụ")
            {
                reportViewer1.Reset();
                ReportDataSource RDS = new ReportDataSource("BaoCaoDichVu");
                this.reportViewer1.LocalReport.DataSources.Add(RDS);
                RDS.Value = this.HOADONDICHVUBindingSource;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKSPM.Report3.rdlc";
                this.HOADONDICHVUTableAdapter.Fill(this.BaoCaoDichVu.HOADONDICHVU, comboBox1.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
            }

        }

        

        private void frm_Baocao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BaoCaoDichVu.HOADONDICHVU' table. You can move, or remove it, as needed.
       

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

       

        private void btn_Quaylai_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Selection s1 = new Selection();
            s1.ShowDialog();
            this.Close();
        }
    }
}
