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
    public partial class frmTrangChu : Form
    {
        bool ChucNangCollapsed;
        bool ThongKeCollapsed;
        public frmTrangChu()
        {
            InitializeComponent();

        }
        private Form currentFromChild;
        private void OpenChildFrom(Form childFrom)
        {
            if(currentFromChild != null)
            {
                currentFromChild.Close();
            }
            currentFromChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childFrom);
            childFrom.BringToFront();
            childFrom.Show();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            sideBarTimer.Start();
        }


        private void ChucNangTimer_Tick(object sender, EventArgs e)
        {
            if (ChucNangCollapsed)
            {
                ChucNangConTainer.Height += 10;
                if (ChucNangConTainer.Height == ChucNangConTainer.MaximumSize.Height)
                {
                    ChucNangCollapsed = false;
                    ChucNangTimer.Stop();
                }
            }
            else
            {
                ChucNangConTainer.Height -= 10;
                if (ChucNangConTainer.Height == ChucNangConTainer.MinimumSize.Height)
                {
                    ChucNangCollapsed = true;
                    ChucNangTimer.Stop();
                }
            }
        }
        private void ThongKeTimer_Tick(object sender, EventArgs e)
        {
            if(ThongKeCollapsed)
            {
                ThongKeContainer.Height += 10;
                if (ThongKeContainer.Height == ThongKeContainer.MaximumSize.Height)
                {
                    ThongKeCollapsed = false;
                    ThongKeTimer.Stop();
                }
            }
            else
            {
                ThongKeContainer.Height -= 10;
                if (ThongKeContainer.Height == ThongKeContainer.MinimumSize.Height)
                {
                    ThongKeCollapsed = true;
                    ThongKeTimer.Stop();
                }
            }
        }
        private void btnChucNang_Click(object sender, EventArgs e)
        {
            ChucNangTimer.Start();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Application.Exit();
                frmDangNhap DN = new frmDangNhap();
                this.Hide();
                DN.ShowDialog();
            }
            
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmBanHang());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeTimer.Start();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            frmBanHang BH = new frmBanHang();
            frmNhanVien NV = new frmNhanVien();
            if (frmDangNhap.CheckLogin == 0)
            {
                btnThongKe.Enabled = false;
                btnQLNhanVien.Enabled = false;
                btnHoaDonNhap.Enabled = false;
                btnLoaiSanPham.Enabled = false;
                btnSanPham.Enabled = false;
            }
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmNhanVien());
        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmQLyLoaiSach());
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmQlySach());
        }
        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmHoaDonBan());
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmHoaDonNhap());
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmDoanhThu());
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new frmTop10SP());
        }
        
    }
}
