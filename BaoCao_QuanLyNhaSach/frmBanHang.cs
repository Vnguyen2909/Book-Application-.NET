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
using DTO;

namespace BaoCao_QuanLyNhaSach
{
    public partial class frmBanHang : Form
    {
        public int Selectname;
        public frmBanHang()
        {
            InitializeComponent();
            dgvListProduct.AutoGenerateColumns = false;
        }

        //Tạo mã hóa đơn là ngày giờ hiện tại
        private string GenerateInvoiceCode()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            this.Location = new Point(416, 83);
            dgvListProduct.DataSource = ProductBUS.GetProduct();
            txtMNV.Text = frmDangNhap.manv.ToString();
            //txtTenNV.Text = frmDangNhap.fullname.ToString();
            txtMHD.Text = GenerateInvoiceCode();
        }

        private int CheckCartExist(string masach)
        {
            foreach (DataGridViewRow row in DgvListHoaDon.Rows)
            {
                if (row.Cells["colID"].Value.ToString() == masach)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private decimal CaculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in DgvListHoaDon.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["ColSoLuong"].Value);
                decimal unitPrice = Convert.ToDecimal(row.Cells["ColDonGia"].Value);
                total += qty * unitPrice;
            }
            return total;
        }

        private void dgvListProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvListProduct.Columns["colImage"].Index)
            {
                e.Value = Image.FromFile(@"images\" + e.Value);
            }
        }

        private void dgvListProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvListProduct.SelectedRows[0];
            if (Convert.ToInt32(selectedRow.Cells["colStock"].Value) != 0)
            {
                string id = Convert.ToString(selectedRow.Cells["colPId"].Value);
                string name = selectedRow.Cells["colProductName"].Value.ToString();
                decimal price = Convert.ToDecimal(selectedRow.Cells["colPrice"].Value);
                int search = CheckCartExist(id);
                if (search == -1)
                {
                    DgvListHoaDon.Rows.Add(id, name, 1, price);
                }
                else if (Convert.ToInt32(dgvListProduct.SelectedRows[0].Cells["colStock"].Value) > Convert.ToInt32(DgvListHoaDon.Rows[search].Cells["ColSoLuong"].Value))
                {
                    int qty = Convert.ToInt32(DgvListHoaDon.Rows[search].Cells["ColSoLuong"].Value) + 1;
                    DgvListHoaDon.Rows[search].Cells["ColSoLuong"].Value = qty;
                }
                else
                {
                    MessageBox.Show("Vượt quá SLTK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                lblTotal.Text = CaculateTotal().ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvListProduct.DataSource = ProductBUS.GetByName(txtSearch.Text);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DgvListHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không thể thanh toán vì không có sản phẩm trong hoá đơn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    InvoiceSale invoice = new InvoiceSale
                    {
                        MAHD = txtMHD.Text,
                        //MANV = cboStaffName.SelectedValue.ToString(),
                        MANV = txtMNV.Text.ToString(),
                        THOIGIAN = DateTime.Now,
                        TONGTIEN = CaculateTotal(),
                        TRANGTHAI = true
                    };
                    if (InvoiceSaleBUS.Add(invoice))
                    {
                        MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvListProduct.DataSource = ProductBUS.GetProduct();
                    }

                    //InvoiceSaleBUS.Add(invoice);
                    dgvListProduct.DataSource = ProductBUS.GetProduct();
                    /*if (InvoiceSaleBUS.Add(invoice))
                    {
                        MessageBox.Show("Thanh toán thành cônBg");
                        dgvListProduct.DataSource = ProductBUS.GetProduct();
                    }*/
                    invoice = InvoiceSaleBUS.GetByMAHD(invoice.MAHD);
                    foreach (DataGridViewRow row in DgvListHoaDon.Rows)
                    {
                        InvoiceSaleDetail invoiceSaleDetail = new InvoiceSaleDetail
                        {
                            MAHD = invoice.MAHD,
                            MASACH = row.Cells["ColID"].Value.ToString(),
                            GIATIEN = Convert.ToDecimal(row.Cells["ColDonGia"].Value),
                            SL = Convert.ToInt32(row.Cells["ColSoLuong"].Value)
                        };
                        InvoiceSaleDetailBUS.Add(invoiceSaleDetail);
                        ProductBUS.SubtrackStock(invoiceSaleDetail.MASACH, invoiceSaleDetail.SL);
                    }
                    DgvListHoaDon.Rows.Clear();
                    dgvListProduct.DataSource = ProductBUS.GetProduct();
                    txtMHD.Text = GenerateInvoiceCode();
                    lblTotal.Text = "0.000";
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            var f = new frmReportHoaDon();
            f.ShowDialog();

            // Hiển thị report
            f.Show();
            this.Hide();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DgvListHoaDon.Rows.Count != 0)
                {
                    int rowIndex = DgvListHoaDon.CurrentCell.RowIndex;
                    decimal rowPrice = Convert.ToDecimal(DgvListHoaDon.CurrentRow.Cells["ColDonGia"].Value);
                    int rowQty = Convert.ToInt32(DgvListHoaDon.CurrentRow.Cells["ColSoLuong"].Value);
                    decimal total = Convert.ToDecimal(lblTotal.Text);
                    DgvListHoaDon.Rows.RemoveAt(rowIndex);
                    total -= rowPrice * rowQty;
                    lblTotal.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("Không thể xoá vì không có dữ liệu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaALL_Click(object sender, EventArgs e)
        {
            DgvListHoaDon.Rows.Clear();
            lblTotal.Text = "0.000";
        }
    }
}
