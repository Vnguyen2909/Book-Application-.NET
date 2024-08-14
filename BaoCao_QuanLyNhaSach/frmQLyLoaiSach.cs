using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace BaoCao_QuanLyNhaSach
{
    public partial class frmQLyLoaiSach : Form
    {
        public frmQLyLoaiSach()
        {
            InitializeComponent();
            dgvLoaiSach.AutoGenerateColumns = false;
        }

        private void frmQLyLoaiSach_Load(object sender, EventArgs e)
        {
            this.Location = new Point(416, 83);
            dgvLoaiSach.DataSource = ProductTypeBUS.GetProductType();
        }

        //Lấy dữ liệu nhập từ ng dùng
        private ProductType GetFormData()
        {
            if (txtMaLoaiSach.Text == "" || txtTenLoaiSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            return new ProductType
            {
                MALOAISACH = Convert.ToInt32(txtMaLoaiSach.Text),
                LOAISACH = txtTenLoaiSach.Text
            };
        } 

        private void ClearForm()
        {
            txtTenLoaiSach.Text = "";
            txtMaLoaiSach.Text = "";
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtMaLoaiSach.Text == "" || txtTenLoaiSach.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtMaLoaiSach.Focus();
                }
                else if (!ProductTypeBUS.CheckID(int.Parse(txtMaLoaiSach.Text)))
                {
                    MessageBox.Show("Mã loại sách đã tồn tại, vui lòng đổi Mã loại sách!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    txtMaLoaiSach.Focus();
                }
                else if (!ProductTypeBUS.CheckName(txtTenLoaiSach.Text))
                {
                    MessageBox.Show("Tên loại sách đã tồn tại, vui lòng đổi Tên loại sách!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    txtTenLoaiSach.Focus();
                }
                else
                {
                    ProductType PT = GetFormData();
                    if (ProductTypeBUS.AddProductType(PT))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvLoaiSach.DataSource = ProductTypeBUS.GetProductType();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ProductType pt = GetFormData();
            if (MessageBox.Show("Bạn đang ghi đè dữ kiệu loại sách tồn tại, tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!ProductTypeBUS.CheckName(txtTenLoaiSach.Text))
                {
                    MessageBox.Show("Tên loại sách đã tồn tại, vui lòng đổi Tên loại sách!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    txtTenLoaiSach.Focus();
                }
                else if (ProductTypeBUS.EditProductType(pt))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ClearForm();
                    dgvLoaiSach.DataSource = ProductTypeBUS.GetProductType();
                }
            }
            else
            {
                ClearForm();
                dgvLoaiSach.DataSource = ProductTypeBUS.GetProductType();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int masach = int.Parse(dgvLoaiSach.SelectedRows[0].Cells["colMaLoaiSach"].Value.ToString());
            if (MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ProductTypeBUS.DelProductType(masach))
                {
                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    dgvLoaiSach.DataSource = ProductTypeBUS.GetProductType();
                    ClearForm();
                    txtMaLoaiSach.Focus();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvLoaiSach.DataSource = ProductTypeBUS.GetByName(txtSearch.Text);
        }

        private void txtMaLoaiSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvLoaiSach.DataSource = ProductTypeBUS.GetProductType();
            txtSearch.Clear();
            txtMaLoaiSach.Enabled = true;
            txtMaLoaiSach.Focus();
        }

        private void dgvLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvLoaiSach.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvLoaiSach.Rows[rowIndex];
            txtMaLoaiSach.Text = row.Cells["colMaLoaiSach"].Value.ToString();
            txtTenLoaiSach.Text = row.Cells["colTenLoaiSach"].Value.ToString();
            txtMaLoaiSach.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvLoaiSach.DataSource = ProductTypeBUS.GetProductType();
            txtSearch.Clear();
        }
    }
}
