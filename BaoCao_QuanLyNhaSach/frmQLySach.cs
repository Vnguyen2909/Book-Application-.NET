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
using System.IO;

namespace BaoCao_QuanLyNhaSach
{
    public partial class frmQlySach : Form
    {
        public string SelectedID;
        public frmQlySach()
        {
            InitializeComponent();
            dgvProduct.AutoGenerateColumns = false;
        }

        private Product GetFormData()
        {
            return new Product
            {
                MASACH = txtBookID.Text,
                MALOAISACH = Convert.ToInt32(cboBookType.SelectedValue),
                TENSACH = txtBookName.Text,
                MATACGIA = Convert.ToInt32(cboTacGia.SelectedValue),
                MANHAXUATBAN = Convert.ToInt32(cboTacGia.SelectedValue),
                GIATIEN = Convert.ToDecimal(txtPrice.Text),
                SLTK = Convert.ToInt32(txtQuantity.Text),
                ANH = DateTime.Now.ToString("yyyyMMdd_hhmmss") + Path.GetExtension(openFileDialog1.FileName),
            };
        }

        private void ClearForm()
        {
            txtBookName.Text = "";
           
            txtBookID.Text = "";
            txtPrice.Text = "";
            
            txtQuantity.Text = "";
            picAnh.Image = null;
        }

        private void picAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picAnh.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void frmQlySach_Load(object sender, EventArgs e)
        {
            this.Location = new Point(416, 83);
            dgvProduct.DataSource = ProductBUS.GetProduct();

            cboBookType.DataSource = ProductTypeBUS.GetProductType();

            cboBookType.DisplayMember = "LOAISACH";
            cboBookType.ValueMember = "MALOAISACH";
        }

        private void dgvProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvProduct.Columns["colImage"].Index)
            {
                e.Value = Image.FromFile(@"images\" + e.Value);
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedID = dgvProduct.CurrentRow.Cells["colBookID"].Value.ToString();
            Product product = ProductBUS.Get(SelectedID);
            txtBookID.Text = product.MASACH;
            txtBookName.Text = product.TENSACH;
            /*cboBookType. = Convert.ToString(product.MALOAISACH);*/ //loi can sua (da sua dc)
            cboBookType.SelectedIndex = cboBookType.FindStringExact(dgvProduct.CurrentRow.Cells["colType"].Value.ToString());
            cboTacGia.SelectedIndex = cboTacGia.FindStringExact(dgvProduct.CurrentRow.Cells["colAuthor"].Value.ToString());
            cboNXB.SelectedIndex = cboNXB.FindStringExact(dgvProduct.CurrentRow.Cells["colPublishing"].Value.ToString());
            txtPrice.Text = Convert.ToString(product.GIATIEN);
            txtQuantity.Text = Convert.ToString(product.SLTK);
            picAnh.ImageLocation = "images/" + product.ANH;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBookID_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvProduct.DataSource = ProductBUS.GetByName(txtSearch.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string temp = dgvProduct.CurrentRow.Cells["colBookName"].Value.ToString();
                if (txtBookName.Text == temp)
                {
                    MessageBox.Show("Thêm không thành công vì trùng tên sách", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else if (txtBookID.Text == "" || txtBookName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "" || picAnh.Image == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    Product product = GetFormData();
                    if (ProductBUS.AddProduct(product))
                    {
                        picAnh.Image.Save(@"images/" + product.ANH);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        this.frmQlySach_Load(sender, e);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                dgvProduct.DataSource = ProductBUS.GetProduct();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masach = dgvProduct.SelectedRows[0].Cells["colBookID"].Value.ToString();
            if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ProductBUS.Del(masach))
                {
                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    dgvProduct.DataSource = ProductBUS.GetProduct();
                    ClearForm();
                }
                else
                {
                    if (InvoiceImportDetailBUS.CountProductImport(masach) > 0 || InvoiceSaleDetailBUS.CountProductSale(masach) > 0)
                    {
                        if (MessageBox.Show("Để xoá dữ liệu sách này sẽ cần xoá dữ liệu sách có trong chi tiết hoá đơn bán/nhập, tiếp tục ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            InvoiceImportDetailBUS.DeleteWithMASACH(masach);
                            InvoiceSaleDetailBUS.DeleteWithMASACH(masach);
                            if (ProductBUS.Del(masach))
                            {
                                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                dgvProduct.DataSource = ProductBUS.GetProduct();
                                ClearForm();
                            }
                        }
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        ClearForm();
                    }
                }
            }
            else
            {
                dgvProduct.DataSource = ProductBUS.GetProduct();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Lưu ý, bạn đang ghi đè dữ liệu sách đã tồn tại, Tiếp tục ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Product product = GetFormData();
                if (ProductBUS.Edit(product))
                {
                    picAnh.Image.Save(@"images/" + product.ANH);
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProduct.DataSource = dgvProduct.DataSource = ProductBUS.GetProduct();
                    this.btnLamMoi_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.frmQlySach_Load(sender, e);
        }
    }
}
