using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace BaoCao_QuanLyNhaSach
{
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void rdo_DTNgay_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Ngay.Enabled = true;
            dtp_ngay.Enabled = true;
            lbl_TuNgay.Enabled = false;
            lbl_DenNgay.Enabled = false;
            dtp_TuNgay.Enabled = false;
            dtp_DenNgay.Enabled = false;
        }

        void TongTien()
        {
            DataTable dt = InvoiceSaleDAO.GetStat();
            DataView dv = new DataView(dt);
            decimal sum = 0;
            foreach (DataGridViewRow row in dgvStatistics.Rows)
            {
                // Check if the cell value is numeric
                if (decimal.TryParse(row.Cells["colStat"].Value.ToString(), out decimal cellValue))
                {
                    sum += cellValue;
                }
            }
            lbl_TongDT.Text = sum.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvStatistics.DataSource = InvoiceSaleBUS.GetStat();
            dtp_ngay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtp_DenNgay.Value = DateTime.Now;

            TongTien();
            lbl_Ngay.Enabled = false;
            lbl_TuNgay.Enabled = false;
            lbl_DenNgay.Enabled = false;
            dtp_ngay.Enabled = false;
            dtp_TuNgay.Enabled = false;
            dtp_DenNgay.Enabled = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvStatistics.DataSource = InvoiceSaleBUS.GetStat();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdo_DTNgay.Checked)
            {
                DateTime dt = dtp_ngay.Value.Date;
                dgvStatistics.DataSource = InvoiceSaleBUS.GetDay(dt);
                TongTien();
            }
            else
            {
                dgvStatistics.DataSource = InvoiceSaleBUS.GetDayToDay(dtp_TuNgay.Value.Date, dtp_DenNgay.Value);
                TongTien();

            }
        }

        private void rdo_DT_CheckedChanged(object sender, EventArgs e)
        {
            lbl_TuNgay.Enabled = true;
            lbl_DenNgay.Enabled = true;
            dtp_TuNgay.Enabled = true;
            dtp_DenNgay.Enabled = true;
            lbl_Ngay.Enabled = false;
            dtp_ngay.Enabled = false;
        }

        private void btn_InDoanhThu_Click(object sender, EventArgs e)
        {
            var f = new frmReport();
            //f.ShowDialog();
            var dataTable = InvoiceSaleBUS.GetDayToDay(dtp_ngay.Value, dtp_ngay.Value);

            // Gắn dữ liệu vào report
            f.SetDataSource(dataTable);

            // Hiển thị report
            f.Show();
            this.Hide();
        }
    }
}
