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
    public partial class fDangNhapQuanLy : Form
    {
        public fDangNhapQuanLy()
        {
            InitializeComponent();
        }

        TaiKhoanBUS user = new TaiKhoanBUS();

        private void LoadfDangNhapQL()
        {
            txtID.Text = "";
            txtPass.Text = "";
        }

        private void fDangNhapQuanLy_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }

        private void fDangNhapQuanLy_Load(object sender, EventArgs e)
        {
            LoadfDangNhapQL();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Trở lại đặt hàng.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    fDatHang f = new fDatHang();
                    f.Show();
                    this.Hide();
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
                if (user.DangNhapBUS(txtID.Text, txtPass.Text) == -1)
                {
                    MessageBox.Show("Sai tên đăng nhập. Hãy nhập lại tên đăng nhập.", "Thông báo", MessageBoxButtons.OK);
                    txtID.Text = "";
                    txtPass.Text = "";
                }
                if (user.DangNhapBUS(txtID.Text, txtPass.Text) == -2)
                {
                    MessageBox.Show("Sai mật khẩu. Hãy nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK);
                    txtPass.Text = "";
                }
                if (user.DangNhapBUS(txtID.Text, txtPass.Text) == 2)
                {
                    MessageBox.Show("Thông tin này chỉ dành cho Quản lý.", "Thông báo", MessageBoxButtons.OK);
                    fDatHang f = new fDatHang();
                    f.Show();
                    this.Hide();
                }
                if (user.DangNhapBUS(txtID.Text, txtPass.Text) == 1)
                {
                    fQuanLy f = new fQuanLy();
                    f.Show();
                    this.Hide();
                }
            }
        }

    }
}
