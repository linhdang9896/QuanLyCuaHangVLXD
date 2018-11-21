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
using DAO;
using DTO.Entity;

namespace VLXD
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        TaiKhoanBUS user = new TaiKhoanBUS();

        private void LoadfLogin()
        {
            txtID.Text = "";
            txtPass.Text = "";
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            LoadfLogin();
        }

        private void fLogin_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Hãy nhập tên đăng nhập.", "Thông báo", MessageBoxButtons.OK);
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                int kq = user.DangNhapBUS(txtID.Text, txtPass.Text);
                if (kq == -1)
                {
                    MessageBox.Show("Sai tên đăng nhập. Hãy nhập lại tên đăng nhập.", "Thông báo", MessageBoxButtons.OK);
                    txtID.Text = "";
                    txtPass.Text = "";
                }
                else if (kq == -2)
                {
                    MessageBox.Show("Sai mật khẩu. Hãy nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK);
                    txtPass.Text = "";
                }
                // 1 ->Quản lý, 2 ->Nhân viên
                else if (kq == 1 || kq == 2)
                {
                    fDatHang f = new fDatHang();
                    f.Show();
                    this.Hide();
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        int eyeClick = 1;
        private void lbXemMatKhau_Click(object sender, EventArgs e)
        {
            if (eyeClick % 2 == 0)
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }
            eyeClick++;
        }
    }
}
