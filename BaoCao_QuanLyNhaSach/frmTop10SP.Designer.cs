namespace BaoCao_QuanLyNhaSach
{
    partial class frmTop10SP
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTop10 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublishing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuying = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop10)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(274, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(612, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "TOP 10 SẢN PHẨM BÁN CHẠY";
            // 
            // dgvTop10
            // 
            this.dgvTop10.AllowUserToAddRows = false;
            this.dgvTop10.AllowUserToDeleteRows = false;
            this.dgvTop10.AllowUserToResizeRows = false;
            this.dgvTop10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTop10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colImage,
            this.colBookName,
            this.colAuthor,
            this.colPublishing,
            this.colBuying});
            this.dgvTop10.Location = new System.Drawing.Point(52, 140);
            this.dgvTop10.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTop10.Name = "dgvTop10";
            this.dgvTop10.ReadOnly = true;
            this.dgvTop10.RowHeadersVisible = false;
            this.dgvTop10.RowTemplate.Height = 100;
            this.dgvTop10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop10.Size = new System.Drawing.Size(1069, 616);
            this.dgvTop10.TabIndex = 10;
            this.dgvTop10.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTop10_CellFormatting);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "MASACH";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colImage
            // 
            this.colImage.DataPropertyName = "ANH";
            this.colImage.HeaderText = "Hình ảnh";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            // 
            // colBookName
            // 
            this.colBookName.DataPropertyName = "TENSACH";
            this.colBookName.HeaderText = "Tên sách / truyện";
            this.colBookName.Name = "colBookName";
            this.colBookName.ReadOnly = true;
            // 
            // colAuthor
            // 
            this.colAuthor.DataPropertyName = "TENTACGIA";
            this.colAuthor.HeaderText = "Tác giả";
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.ReadOnly = true;
            // 
            // colPublishing
            // 
            this.colPublishing.DataPropertyName = "NHAXUATBAN";
            this.colPublishing.HeaderText = "Nhà xuất bản";
            this.colPublishing.Name = "colPublishing";
            this.colPublishing.ReadOnly = true;
            // 
            // colBuying
            // 
            this.colBuying.DataPropertyName = "TONGLUOTMUA";
            this.colBuying.HeaderText = "Tổng số lượng sản phẩm được bán";
            this.colBuying.Name = "colBuying";
            this.colBuying.ReadOnly = true;
            // 
            // frmTop10SP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 800);
            this.Controls.Add(this.dgvTop10);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1170, 800);
            this.MinimumSize = new System.Drawing.Size(1170, 800);
            this.Name = "frmTop10SP";
            this.Text = "frmTop10SP";
            this.Load += new System.EventHandler(this.frmTop10SP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTop10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublishing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuying;
    }
}