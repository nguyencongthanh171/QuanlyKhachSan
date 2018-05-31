namespace QuanLyKSPM
{
    partial class frm_Baocao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.HOADONDICHVUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BaoCaoDichVu = new QuanLyKSPM.BaoCaoDichVu();
            this.btn_Quaylai = new System.Windows.Forms.Button();
            this.btn_BaoCaoDatPhong = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HOADONDATTIECBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BaoCaoDatTiec = new QuanLyKSPM.BaoCaoDatTiec();
            this.HOADONDATTIECTableAdapter = new QuanLyKSPM.BaoCaoDatTiecTableAdapters.HOADONDATTIECTableAdapter();
            this.HOADONPHONGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BaoCaoHDP = new QuanLyKSPM.BaoCaoHDP();
            this.HOADONPHONGTableAdapter = new QuanLyKSPM.BaoCaoHDPTableAdapters.HOADONPHONGTableAdapter();
            this.HOADONDICHVUTableAdapter = new QuanLyKSPM.BaoCaoDichVuTableAdapters.HOADONDICHVUTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONDICHVUBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONDATTIECBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDatTiec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONPHONGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoHDP)).BeginInit();
            this.SuspendLayout();
            // 
            // HOADONDICHVUBindingSource
            // 
            this.HOADONDICHVUBindingSource.DataMember = "HOADONDICHVU";
            this.HOADONDICHVUBindingSource.DataSource = this.BaoCaoDichVu;
            // 
            // BaoCaoDichVu
            // 
            this.BaoCaoDichVu.DataSetName = "BaoCaoDichVu";
            this.BaoCaoDichVu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_Quaylai
            // 
            this.btn_Quaylai.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_Quaylai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Quaylai.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Quaylai.Location = new System.Drawing.Point(12, 12);
            this.btn_Quaylai.Name = "btn_Quaylai";
            this.btn_Quaylai.Size = new System.Drawing.Size(75, 23);
            this.btn_Quaylai.TabIndex = 0;
            this.btn_Quaylai.Text = "Quay lại";
            this.btn_Quaylai.UseVisualStyleBackColor = false;
            this.btn_Quaylai.Click += new System.EventHandler(this.btn_Quaylai_Click_1);
            // 
            // btn_BaoCaoDatPhong
            // 
            this.btn_BaoCaoDatPhong.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_BaoCaoDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BaoCaoDatPhong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_BaoCaoDatPhong.Location = new System.Drawing.Point(477, 62);
            this.btn_BaoCaoDatPhong.Name = "btn_BaoCaoDatPhong";
            this.btn_BaoCaoDatPhong.Size = new System.Drawing.Size(103, 37);
            this.btn_BaoCaoDatPhong.TabIndex = 1;
            this.btn_BaoCaoDatPhong.Text = "Xem báo cáo";
            this.btn_BaoCaoDatPhong.UseVisualStyleBackColor = false;
            this.btn_BaoCaoDatPhong.Click += new System.EventHandler(this.btn_BaoCaoDatPhong_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.comboBox1.Location = new System.Drawing.Point(349, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tháng";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "BaoCaoDichVu";
            reportDataSource1.Value = this.HOADONDICHVUBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKSPM.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 122);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(830, 437);
            this.reportViewer1.TabIndex = 18;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Phòng",
            "Đặt Tiệc",
            "Dịch vụ"});
            this.comboBox2.Location = new System.Drawing.Point(132, 69);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Loại báo cáo";
            // 
            // HOADONDATTIECBindingSource
            // 
            this.HOADONDATTIECBindingSource.DataMember = "HOADONDATTIEC";
            this.HOADONDATTIECBindingSource.DataSource = this.BaoCaoDatTiec;
            // 
            // BaoCaoDatTiec
            // 
            this.BaoCaoDatTiec.DataSetName = "BaoCaoDatTiec";
            this.BaoCaoDatTiec.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HOADONDATTIECTableAdapter
            // 
            this.HOADONDATTIECTableAdapter.ClearBeforeFill = true;
            // 
            // HOADONPHONGBindingSource
            // 
            this.HOADONPHONGBindingSource.DataMember = "HOADONPHONG";
            this.HOADONPHONGBindingSource.DataSource = this.BaoCaoHDP;
            // 
            // BaoCaoHDP
            // 
            this.BaoCaoHDP.DataSetName = "BaoCaoHDP";
            this.BaoCaoHDP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HOADONPHONGTableAdapter
            // 
            this.HOADONPHONGTableAdapter.ClearBeforeFill = true;
            // 
            // HOADONDICHVUTableAdapter
            // 
            this.HOADONDICHVUTableAdapter.ClearBeforeFill = true;
            // 
            // frm_Baocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 573);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_BaoCaoDatPhong);
            this.Controls.Add(this.btn_Quaylai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Baocao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baocao";
            this.Load += new System.EventHandler(this.frm_Baocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HOADONDICHVUBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONDATTIECBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDatTiec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONPHONGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoHDP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Quaylai;
        private System.Windows.Forms.Button btn_BaoCaoDatPhong;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource HOADONPHONGBindingSource;
        private BaoCaoHDP BaoCaoHDP;
        private BaoCaoHDPTableAdapters.HOADONPHONGTableAdapter HOADONPHONGTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource HOADONDATTIECBindingSource;
        private BaoCaoDatTiec BaoCaoDatTiec;
        private BaoCaoDatTiecTableAdapters.HOADONDATTIECTableAdapter HOADONDATTIECTableAdapter;
        private System.Windows.Forms.BindingSource HOADONDICHVUBindingSource;
        private BaoCaoDichVu BaoCaoDichVu;
        private BaoCaoDichVuTableAdapters.HOADONDICHVUTableAdapter HOADONDICHVUTableAdapter;
    }
}