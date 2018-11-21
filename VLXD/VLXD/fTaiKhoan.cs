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
    public partial class fTaiKhoan : Form
    {
        public fTaiKhoan()
        {
            InitializeComponent();
        }

        TaiKhoanBUS userBUS = new TaiKhoanBUS();
        NhanVienBUS nvBUS = new NhanVienBUS();

        private void fTaiKhoan_Load(object sender, EventArgs e)
        {
            cbMaNV.DataSource = nvBUS.LoadNVBUS();
            cbMaNV.DisplayMember = "MaNV";
        }

        private void cbMaNVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                NhanVien nv = cb.SelectedValue as NhanVien;
                txtTenNV.Text = (nv.HoNV + " " + nv.TenNV).ToString();
            }
        }

        int eyeClick = 1;
        private void lbXemMatKhau_Click(object sender, EventArgs e)
        {
            if (eyeClick % 2 == 0)
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            eyeClick++;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    this.Hide();
                    fDatHang f = new fDatHang();
                    f.Show();
                    break;
                default:
                    break;
            }
        }

        private void UpdateUserMaNV() 
        {
            TaiKhoan user = new TaiKhoan();
            user.TenTaiKhoan = txtTenDangNhap.Text;
            user.MatKhau = txtMatKhau.Text;
            user.MaNV = int.Parse(cbMaNV.Text);

            userBUS.UpdateUserMaNVBUS(user);
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" || txtMatKhau.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa tài khoản?" + txtTenDangNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateUserMaNV();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền Đầy Đủ và Đúng thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
