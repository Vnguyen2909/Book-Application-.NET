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

namespace BaoCao_QuanLyNhaSach
{
	public partial class frmDangNhap : Form
	{

        public static string manv;
        public static string fullname;
        public static int CheckLogin;
        public frmDangNhap()
		{
			InitializeComponent();
		}

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (AccountBUS.LoginAccount(txtUserName.Text, txtPassword.Text) == true)
            {
                string name = txtUserName.Text;
                fullname = AccountBUS.GetFullName(name);
                manv = AccountBUS.GetMANV(name);
                CheckLogin = AccountBUS.CheckAdmin(txtUserName.Text, txtPassword.Text);
                frmTrangChu trangchu = new frmTrangChu();
                this.Hide();
                trangchu.ShowDialog();
                this.Close();
            }
            else if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Nhập sai tên tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxShowPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassWord.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }
    }
}
