
namespace BaoCao_QuanLyNhaSach
{
    partial class frmDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoanhThu));
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo_DTNgay = new System.Windows.Forms.RadioButton();
            this.rdo_DT = new System.Windows.Forms.RadioButton();
            this.lbl_DenNgay = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtp_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbl_TuNgay = new System.Windows.Forms.Label();
            this.dtp_ngay = new System.Windows.Forms.DateTimePicker();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.lbl_Ngay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_TongDT = new System.Windows.Forms.Label();
            this.btn_InDoanhThu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.AllowUserToResizeRows = false;
            this.dgvStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colStat});
            this.dgvStatistics.Location = new System.Drawing.Point(29, 121);
            this.dgvStatistics.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.ReadOnly = true;
            this.dgvStatistics.RowHeadersVisible = false;
            this.dgvStatistics.RowHeadersWidth = 51;
            this.dgvStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatistics.Size = new System.Drawing.Size(587, 568);
            this.dgvStatistics.TabIndex = 17;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "THOIGIAN";
            this.colDate.HeaderText = "Thời gian";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colStat
            // 
            this.colStat.DataPropertyName = "DOANHTHU";
            this.colStat.HeaderText = "Doanh Thu";
            this.colStat.MinimumWidth = 6;
            this.colStat.Name = "colStat";
            this.colStat.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(1170, 100);
            this.panel1.MinimumSize = new System.Drawing.Size(1170, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 100);
            this.panel1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(434, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "DOANH THU";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_DTNgay);
            this.groupBox1.Controls.Add(this.rdo_DT);
            this.groupBox1.Controls.Add(this.lbl_DenNgay);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.dtp_TuNgay);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lbl_TuNgay);
            this.groupBox1.Controls.Add(this.dtp_ngay);
            this.groupBox1.Controls.Add(this.dtp_DenNgay);
            this.groupBox1.Controls.Add(this.lbl_Ngay);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(648, 137);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(498, 473);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // rdo_DTNgay
            // 
            this.rdo_DTNgay.AutoSize = true;
            this.rdo_DTNgay.Location = new System.Drawing.Point(33, 51);
            this.rdo_DTNgay.Name = "rdo_DTNgay";
            this.rdo_DTNgay.Size = new System.Drawing.Size(179, 23);
            this.rdo_DTNgay.TabIndex = 23;
            this.rdo_DTNgay.TabStop = true;
            this.rdo_DTNgay.Text = "Doanh thu theo ngày";
            this.rdo_DTNgay.UseVisualStyleBackColor = true;
            this.rdo_DTNgay.CheckedChanged += new System.EventHandler(this.rdo_DTNgay_CheckedChanged);
            // 
            // rdo_DT
            // 
            this.rdo_DT.AutoSize = true;
            this.rdo_DT.Location = new System.Drawing.Point(33, 179);
            this.rdo_DT.Name = "rdo_DT";
            this.rdo_DT.Size = new System.Drawing.Size(105, 23);
            this.rdo_DT.TabIndex = 23;
            this.rdo_DT.TabStop = true;
            this.rdo_DT.Text = "Doanh thu";
            this.rdo_DT.UseVisualStyleBackColor = true;
            this.rdo_DT.CheckedChanged += new System.EventHandler(this.rdo_DT_CheckedChanged);
            // 
            // lbl_DenNgay
            // 
            this.lbl_DenNgay.AutoSize = true;
            this.lbl_DenNgay.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_DenNgay.Location = new System.Drawing.Point(50, 309);
            this.lbl_DenNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DenNgay.Name = "lbl_DenNgay";
            this.lbl_DenNgay.Size = new System.Drawing.Size(97, 22);
            this.lbl_DenNgay.TabIndex = 19;
            this.lbl_DenNgay.Text = "Đến ngày: ";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Location = new System.Drawing.Point(297, 382);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 52);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtp_TuNgay
            // 
            this.dtp_TuNgay.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_TuNgay.Location = new System.Drawing.Point(165, 238);
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.Size = new System.Drawing.Size(298, 28);
            this.dtp_TuNgay.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearch.Image = global::BaoCao_QuanLyNhaSach.Properties.Resources.loupe__1_;
            this.btnSearch.Location = new System.Drawing.Point(135, 382);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(147, 52);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbl_TuNgay
            // 
            this.lbl_TuNgay.AutoSize = true;
            this.lbl_TuNgay.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_TuNgay.Location = new System.Drawing.Point(50, 241);
            this.lbl_TuNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TuNgay.Name = "lbl_TuNgay";
            this.lbl_TuNgay.Size = new System.Drawing.Size(83, 22);
            this.lbl_TuNgay.TabIndex = 10;
            this.lbl_TuNgay.Text = "Từ ngày:";
            // 
            // dtp_ngay
            // 
            this.dtp_ngay.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_ngay.Location = new System.Drawing.Point(164, 110);
            this.dtp_ngay.Name = "dtp_ngay";
            this.dtp_ngay.Size = new System.Drawing.Size(298, 28);
            this.dtp_ngay.TabIndex = 14;
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_DenNgay.Location = new System.Drawing.Point(166, 306);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.Size = new System.Drawing.Size(297, 28);
            this.dtp_DenNgay.TabIndex = 18;
            // 
            // lbl_Ngay
            // 
            this.lbl_Ngay.AutoSize = true;
            this.lbl_Ngay.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_Ngay.Location = new System.Drawing.Point(50, 113);
            this.lbl_Ngay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Ngay.Name = "lbl_Ngay";
            this.lbl_Ngay.Size = new System.Drawing.Size(58, 22);
            this.lbl_Ngay.TabIndex = 10;
            this.lbl_Ngay.Text = "Ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 730);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tổng doanh thu";
            // 
            // lbl_TongDT
            // 
            this.lbl_TongDT.AutoSize = true;
            this.lbl_TongDT.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TongDT.Location = new System.Drawing.Point(456, 730);
            this.lbl_TongDT.Name = "lbl_TongDT";
            this.lbl_TongDT.Size = new System.Drawing.Size(0, 21);
            this.lbl_TongDT.TabIndex = 20;
            // 
            // btn_InDoanhThu
            // 
            this.btn_InDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InDoanhThu.Image = ((System.Drawing.Image)(resources.GetObject("btn_InDoanhThu.Image")));
            this.btn_InDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InDoanhThu.Location = new System.Drawing.Point(783, 633);
            this.btn_InDoanhThu.Name = "btn_InDoanhThu";
            this.btn_InDoanhThu.Size = new System.Drawing.Size(192, 69);
            this.btn_InDoanhThu.TabIndex = 21;
            this.btn_InDoanhThu.Text = "      In Doanh Thu";
            this.btn_InDoanhThu.UseVisualStyleBackColor = true;
            this.btn_InDoanhThu.Click += new System.EventHandler(this.btn_InDoanhThu_Click);
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 800);
            this.Controls.Add(this.btn_InDoanhThu);
            this.Controls.Add(this.lbl_TongDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStatistics);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoanhThu";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_ngay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbl_Ngay;
        private System.Windows.Forms.Label lbl_DenNgay;
        private System.Windows.Forms.DateTimePicker dtp_TuNgay;
        private System.Windows.Forms.Label lbl_TuNgay;
        private System.Windows.Forms.DateTimePicker dtp_DenNgay;
        private System.Windows.Forms.RadioButton rdo_DTNgay;
        private System.Windows.Forms.RadioButton rdo_DT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TongDT;
        private System.Windows.Forms.Button btn_InDoanhThu;
    }
}