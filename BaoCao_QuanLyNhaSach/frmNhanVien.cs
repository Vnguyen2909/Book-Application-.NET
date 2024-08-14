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
    public partial class frmNhanVien : Form
    {
        private string SelectMaNv;
        public frmNhanVien()
        {
            InitializeComponent();
            dgvAccount.AutoGenerateColumns = false;   //Tắt tự động tạo cột
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            this.Location = new Point(416, 83);
            dgvAccount.DataSource = AccountBUS.GetAccount();
        }

        private Account GetFormData()
        {
            return new Account
            {
                MANV = txtMaNV.Text,
                USERNAME = txtUserName.Text,
                MATKHAU = txtPassWord.Text,
                HOTEN = txtUserName.Text,
                DIACHI = txtDiaChi.Text,
                SDT = txtSDT.Text,
                LaAdmin = ckBoxQL.Checked
            };
        }
        private void ClearFrom()
        {
            txtMaNV.Text = "";
            txtUserName.Text = "";
            txtHoTen.Text = "";
            txtPassWord.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            ckBoxQL.Checked = false;
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string temp = dgvAccount.CurrentRow.Cells["colUsername"].Value.ToString();
                if(txtUserName.Text == temp)
                {
                    MessageBox.Show("User name đã tồn tại, vui lòng đổi username khác!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else if (txtMaNV.Text == "" || txtUserName.Text == "" || txtPassWord.Text == "" || txtDiaChi.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    Account account = GetFormData();
                    if(AccountBUS.AddAccount(account))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        ClearFrom();
                        dgvAccount.DataSource = AccountBUS.GetAccount();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //CHECK XEM CÓ BAO NHIÊU ADMIN
        private int CheckHowManyAdmin()       
        {
            return AccountBUS.GetHowManyAdmin();
        }
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string manv = dgvAccount.SelectedRows[0].Cells["colID"].Value.ToString();
            if(MessageBox.Show("Bạn có chắc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(CheckHowManyAdmin() == 1 && Convert.ToBoolean(dgvAccount.CurrentRow.Cells["colRole"].Value) == true)
                {
                    MessageBox.Show("Xóa không thành công vì cần ít nhất 1 tài khoản Admin");
                }
                else
                {
                    if(AccountBUS.DelAccount(manv))
                    {
                        dgvAccount.DataSource = AccountBUS.GetAccount();
                        ClearFrom();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectMaNv = dgvAccount.SelectedRows[0].Cells["colID"].Value.ToString();
            Account account = AccountBUS.Get(SelectMaNv);
            txtMaNV.Text = account.MANV;
            txtUserName.Text = account.USERNAME;
            txtPassWord.Text = account.MATKHAU;
            txtHoTen.Text = account.HOTEN;
            txtSDT.Text = account.SDT;
            txtDiaChi.Text = account.DIACHI;
            ckBoxQL.Checked = account.LaAdmin;
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Lưu ý: Bạn đang ghi đè đữ liệu nhân viên đã tồn tại. Tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                if(CheckHowManyAdmin() == 1 && Convert.ToBoolean(dgvAccount.CurrentRow.Cells["colRole"].Value) == true && ckBoxQL.Checked == false)
                {
                    MessageBox.Show("Sửa không thành công vì cần ít nhất 1 tài khoản Admin", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    SelectMaNv = dgvAccount.SelectedRows[0].Cells["colID"].Value.ToString();
                    Account acc = GetFormData();
                    if (AccountBUS.Edit(SelectMaNv, acc))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvAccount.DataSource = AccountBUS.GetAccount();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFrom();
            dgvAccount.DataSource = AccountBUS.GetAccount();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvAccount.DataSource = AccountBUS.GetByName(txtSearch.Text);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.FrmNhanVien_Load(sender, e);
            txtSearch.Text = "";
        }
    }
}
