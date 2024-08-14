using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoCao_QuanLyNhaSach
{
    public partial class frmReport : Form
    {
        DoanhThu rpt;
        public frmReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rpt = new DoanhThu();

            //chạy report ko cần nhập lại mật khẩu
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "123", "DESKTOP-KFOVQS4", "DBQL_NhaSach");

            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = false;
            crystalReportViewer1.DisplayStatusBar = false;

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        internal void SetDataSource(DataTable dataTable)
        {
            rpt = new DoanhThu();
            
        }
    }
}
