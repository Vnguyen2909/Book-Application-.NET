using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace BaoCao_QuanLyNhaSach
{
    public partial class frmTop10SP : Form
    {
        public frmTop10SP()
        {
            InitializeComponent();
            dgvTop10.AutoGenerateColumns = false;
        }

        private void dgvTop10_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvTop10.Columns["colImage"].Index)
            {
                e.Value = Image.FromFile(@"images\" + e.Value);
            }
        }

        private void frmTop10SP_Load(object sender, EventArgs e)
        {
            dgvTop10.DataSource = ProductBUS.TOP10();
        }
    }
}
