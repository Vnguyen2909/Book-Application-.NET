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
    public partial class frmHoaDonBan : Form
    {
        public string selectedID;
        public frmHoaDonBan()
        {
            InitializeComponent();
            dgvReceipt.AutoGenerateColumns = false;
            dgvReceiptDetail.AutoGenerateColumns = false;
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            dgvReceipt.DataSource = InvoiceSaleBUS.GetAll();
            dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetAll();
            if (frmDangNhap.CheckLogin == 0)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;

                txtID.Enabled = false;
                txtStaffID.Enabled = false;
                dtpDate.Enabled = false;
                chkCheck.Enabled = false;
                txtTotal.Enabled = false;

                txtRD_ID.Enabled = false;
                txtBookID.Enabled = false;
                txtQuantity.Enabled = false;
                txtPrice.Enabled = false;
            }
        }
        private void ClearForm()
        {
            txtID.Text = "";
            txtStaffID.Text = "";
            dtpDate.Value = DateTime.Now;
            txtTotal.Text = "";
            txtRD_ID.Text = "";
            txtBookID.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            chkCheck.Checked = true;
        }
        private decimal CaculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvReceiptDetail.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["colRD_Qty"].Value);
                decimal unitPrice = Convert.ToDecimal(row.Cells["colRD_Price"].Value);
                total += qty * unitPrice;
            }
            return total;
        }
        private void dgvReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radReceipt.Checked)
            {
                selectedID = dgvReceipt.CurrentRow.Cells["colR_ID"].Value.ToString();
                InvoiceSale invoice = InvoiceSaleBUS.GetByMAHD(selectedID);
                txtID.Text = invoice.MAHD;
                txtStaffID.Text = invoice.MANV;
                dtpDate.Value = invoice.THOIGIAN;
                txtTotal.Text = CaculateTotal().ToString();

                chkCheck.Checked = invoice.TRANGTHAI;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đúng bảng!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void dgvReceiptDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radReceiptDetail.Checked)
            { 
                int selectedID = Convert.ToInt32(dgvReceiptDetail.CurrentRow.Cells["colRID"].Value);
                InvoiceSaleDetail invoice = InvoiceSaleDetailBUS.GetByMAHD(selectedID);
                txtRD_ID.Text = invoice.MAHD;
                txtBookID.Text = invoice.MASACH;
                txtQuantity.Text = invoice.SL.ToString();
                txtPrice.Text = invoice.GIATIEN.ToString();
            }else
            {
                MessageBox.Show("Vui lòng chọn đúng bảng!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        private InvoiceSaleDetail GetFormDataDetail()
        {
            return new InvoiceSaleDetail
            {
                MAHD = txtRD_ID.Text,
                MASACH = txtBookID.Text,
                SL = Convert.ToInt32(txtQuantity.Text),
                GIATIEN = Convert.ToDecimal(txtPrice.Text)
            };
        }
        private InvoiceSale GetFormData()
        {
            return new InvoiceSale
            {
                MAHD = txtID.Text,
                MANV = txtStaffID.Text,
                THOIGIAN = dtpDate.Value,
                TONGTIEN = Convert.ToDecimal(txtTotal.Text),
                TRANGTHAI = Convert.ToBoolean(chkCheck.Checked)
            };
        }

        

        private void dgvReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MAHD = dgvReceipt.CurrentRow.Cells["colR_ID"].Value.ToString();
            dgvReceiptDetail.DataSource = InvoiceSaleBUS.GetCHITIETHD(MAHD);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radReceipt.Checked)
            {
                dgvReceipt.DataSource = InvoiceSaleBUS.GetByName(txtSearch.Text);
            }
            else
            {
                dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetByName(txtSearch.Text);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (radReceipt.Checked)
            {
                dgvReceipt.DataSource = InvoiceSaleBUS.GetAll();
                txtSearch.Text = "";
            }
            else
            {
                dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetAll();
                txtSearch.Text = "";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (radReceipt.Checked) //BẢNG HÓA ĐƠN
            {
                string ma = dgvReceipt.CurrentRow.Cells["colR_ID"].Value.ToString();
                if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (InvoiceSaleBUS.Delete(ma))
                    {
                        MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvReceipt.DataSource = InvoiceSaleBUS.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dgvReceipt.DataSource = InvoiceSaleBUS.GetAll();
                }
            }
            else if (radReceiptDetail.Checked)  ///BẢNG CHI TIẾT HÓA ĐƠN
            {
                if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvReceiptDetail.CurrentRow.Cells["colRID"].Value);
                    if (InvoiceSaleDetailBUS.Delete(id))
                    {
                        MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetAll();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (radReceipt.Checked)
            {
                if (MessageBox.Show("Lưu ý, bạn đang ghi đè dữ liệu hoá đơn đã tồn tại, tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InvoiceSale invoice = GetFormData();
                    if (InvoiceSaleBUS.Edit(invoice))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvReceipt.DataSource = InvoiceSaleBUS.GetAll();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dgvReceipt.DataSource = InvoiceSaleBUS.GetAll();
                    ClearForm();
                }
            }
            else
            {
                if (MessageBox.Show("Lưu ý, bạn đang ghi đè dữ liệu chi tiết hoá đơn đã tồn tại, tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InvoiceSaleDetail invoice = GetFormDataDetail();
                    int id = Convert.ToInt32(dgvReceiptDetail.CurrentRow.Cells["colRID"].Value);
                    if (InvoiceSaleDetailBUS.Edit(id, invoice))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetAll();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        //MessageBox.Show(invoice.MAHD);
                    }
                }
                else
                {
                    dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetAll();
                    ClearForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.frmHoaDonBan_Load(sender, e);
        }
    }
}
