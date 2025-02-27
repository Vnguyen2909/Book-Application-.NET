﻿using System;
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
    public partial class frmHoaDonNhap : Form
    {
        public string selectedID;
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private string GenerateInvoiceCode()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void ClearForm()
        {
            txtStaffID.Text = "";
            dtpDate.Value = DateTime.Now;
            txtTotal.Text = "";
            txtRD_ID.Text = "";
            txtBookID.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            txtID.Text = dtpDate.Text;
            chkCheck.Checked = true;
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvReceipt.DataSource = InvoiceImportBUS.GetAll();
            dgvReceiptDetail.DataSource = InvoiceImportDetailBUS.GetAll();
            dgvMASACH.DataSource = ProductBUS.GetMaSach();
            txtID.Text = GenerateInvoiceCode();
            txtStaffID.Text = frmDangNhap.manv.ToString();

            if (frmDangNhap.CheckLogin == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;

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

        private void dgvMASACH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvMASACH.Columns["colImage"].Index)
            {
                e.Value = Image.FromFile(@"images\" + e.Value);
            }
        }

        private void dgvMASACH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radReceiptDetail.Checked)
            {
                string ma = dgvMASACH.CurrentRow.Cells["colShowBookID"].Value.ToString();
                txtBookID.Text = ma;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đúng bảng!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void txtStaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBookID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radReceipt.Checked)
            {
                dgvReceipt.DataSource = InvoiceImportBUS.GetByName(txtSearch.Text);
            }
            else
            {
                dgvReceiptDetail.DataSource = InvoiceImportDetailBUS.GetByName(txtSearch.Text);
            }
        }
        private InvoiceImport GetFormData()
        {
            return new InvoiceImport
            {
                MAHD = txtID.Text,
                MANV = txtStaffID.Text,
                THOIGIAN = dtpDate.Value,
                TONGTIEN = Convert.ToDecimal(txtTotal.Text),
                TRANGTHAI = Convert.ToBoolean(chkCheck.Checked)
            };
        }

        private InvoiceImportDetail GetFormDataDetail()
        {
            return new InvoiceImportDetail
            {
                MAHD = txtRD_ID.Text,
                MASACH = txtBookID.Text,
                SL = Convert.ToInt32(txtQuantity.Text),
                GIATIEN = Convert.ToDecimal(txtPrice.Text)
            };
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
                InvoiceImport invoice = InvoiceImportBUS.GetByMAHD(selectedID);
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
        private void dgvReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MAHD = dgvReceipt.CurrentRow.Cells["colR_ID"].Value.ToString();
            dgvReceiptDetail.DataSource = InvoiceSaleDetailBUS.GetCHITIETHDNHAP(MAHD);
        }
        private void dgvReceiptDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radReceiptDetail.Checked)
            {
                int selectedID = Convert.ToInt32(dgvReceiptDetail.CurrentRow.Cells["colRID"].Value);
                InvoiceImportDetail invoice = InvoiceImportDetailBUS.GetByMAHD(selectedID);
                txtRD_ID.Text = invoice.MAHD;
                txtBookID.Text = invoice.MASACH;
                txtQuantity.Text = invoice.SL.ToString();
                txtPrice.Text = invoice.GIATIEN.ToString();

            }
            else
            {
                MessageBox.Show("Vui lòng chọn đúng bảng!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (radReceipt.Checked)
            {
                if (txtID.Text == "" || txtStaffID.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InvoiceImport invoice = new InvoiceImport
                        {
                            MAHD = GenerateInvoiceCode(),
                            MANV = txtStaffID.Text,
                            THOIGIAN = dtpDate.Value,
                            //TONGTIEN = Convert.ToDecimal(txtTotal.Text)
                        };
                        if (InvoiceImportBUS.Add(invoice))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            ClearForm();
                            this.frmHoaDonNhap_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            if (radReceiptDetail.Checked)
            {
                if (txtRD_ID.Text == "" || txtBookID.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InvoiceImportDetail invoice = new InvoiceImportDetail
                        {
                            MAHD = txtRD_ID.Text,
                            MASACH = txtBookID.Text,
                            SL = Convert.ToInt32(txtQuantity.Text),
                            GIATIEN = Convert.ToDecimal(txtPrice.Text)
                        };
                        if (InvoiceImportDetailBUS.Add(invoice))
                        {

                            if (MessageBox.Show("Bạn có muốn cộng số lượng trong chi tiết hoá đơn vào SLTK không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ProductBUS.PlusStock(invoice.MASACH, invoice.SL);
                            }
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            txtBookID.Text = "";
                            txtQuantity.Text = "";
                            txtPrice.Text = "";
                            this.frmHoaDonNhap_Load(sender, e);
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (radReceipt.Checked)
            {
                string ma = dgvReceipt.CurrentRow.Cells["colR_ID"].Value.ToString();
                if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (InvoiceImportBUS.Delete(ma))
                    {
                        MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvReceipt.DataSource = InvoiceImportBUS.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dgvReceipt.DataSource = InvoiceImportBUS.GetAll();
                }
                //MessageBox.Show("bảng hoá đơn");
            }
            else
            {
                int id = Convert.ToInt32(dgvReceiptDetail.CurrentRow.Cells["colRID"].Value);
                if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (InvoiceImportDetailBUS.Delete(id))
                    {
                        dgvReceiptDetail.DataSource = InvoiceImportDetailBUS.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dgvReceipt.DataSource = InvoiceImportDetailBUS.GetAll();
                }
                //MessageBox.Show("bảng chi tiết hoá đơn");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (radReceipt.Checked)
            {
                InvoiceImport invoice = GetFormData();
                if (MessageBox.Show("Lưu ý, bạn đang ghi đè dữ liệu hoá đơn nhập đã tồn tại, tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (InvoiceImportBUS.Edit(invoice))
                    {
                        ClearForm();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        dgvReceipt.DataSource = InvoiceImportBUS.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ClearForm();
                    dgvReceiptDetail.DataSource = InvoiceImportBUS.GetAll();
                }
            }
            else
            {
                InvoiceImportDetail invoice = GetFormDataDetail();
                int id = Convert.ToInt32(dgvReceiptDetail.CurrentRow.Cells["colRID"].Value);
                if (MessageBox.Show("Lưu ý, bạn đang ghi đè dữ liệu hoá đơn nhập đã tồn tại, tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (InvoiceImportDetailBUS.Edit(id, invoice))
                    {
                        ClearForm();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvReceiptDetail.DataSource = InvoiceImportDetailBUS.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        //MessageBox.Show(invoice.MAHD);
                    }
                }
                else
                {
                    ClearForm();
                    dgvReceiptDetail.DataSource = InvoiceImportDetailBUS.GetAll();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.frmHoaDonNhap_Load(sender, e);
            ClearForm();
            txtID.Text = GenerateInvoiceCode();
            txtStaffID.Text = frmDangNhap.manv;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                txtPrice.Text = (InvoiceImportDetailBUS.GetPrice(txtBookID.Text) * Convert.ToDecimal(txtQuantity.Text)).ToString();
            }
            else
            {
                txtPrice.Text = "";
            }
        }

        
    }
}
