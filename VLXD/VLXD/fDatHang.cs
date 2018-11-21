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
    public partial class fDatHang : Form
    {
        public fDatHang()
        {
            InitializeComponent();
        }

        SanPhamBUS spBUS = new SanPhamBUS();
        NhanVienBUS nvBUS = new NhanVienBUS();
        HoaDonBUS hdBUS = new HoaDonBUS();
        ChiTietHDBUS cthdBUS = new ChiTietHDBUS();
        KhachHangBUS khBUS = new KhachHangBUS();

        private void fDatHang_Load(object sender, EventArgs e)
        {
            LoadKH();
            LoadHD();

            dgvSP.AutoGenerateColumns = false;
            dgvSP.DataSource = spBUS.LoadSPBUS();

            cbMaKHang.DataSource = khBUS.LoadKHBUS();
            cbMaKHang.DisplayMember = "MaKH";

            cbMaNVien.DataSource = nvBUS.LoadNVBUS();
            cbMaNVien.DisplayMember = "MaNV";

            cbMaSPham.DataSource = spBUS.LoadSPBUS();
            cbMaSPham.DisplayMember = "MaSP";
        }

        #region Khách hàng
        //Hiển thị KH
        private void LoadKH()
        {
            dgvKH.AutoGenerateColumns = false;
            dgvKH.DataSource = khBUS.LoadKHBUS();
        }

        private void tabKH_Click(object sender, EventArgs e)
        {
            LoadKH();
            txtMaKH.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChiKH.Text = "";
            txtSdtKH.Text = "";
            txtTimKH.Text = "";
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaKH.Text = dgvKH.Rows[row].Cells[0].Value.ToString();
                txtHoKH.Text = dgvKH.Rows[row].Cells[1].Value.ToString();
                txtTenKH.Text = dgvKH.Rows[row].Cells[2].Value.ToString();

                if (dgvKH.Rows[row].Cells[3].Value.ToString() == "Nam")
                {
                    rdbNamKH.Checked = true;
                }
                else
                {
                    rdbNuKH.Checked = true;
                }

                txtDiaChiKH.Text = dgvKH.Rows[row].Cells[4].Value.ToString();
                txtSdtKH.Text = dgvKH.Rows[row].Cells[5].Value.ToString();
            }
        }

    //Thêm KH
        private void AddKH()
        {
            KhachHang khToAdd = new KhachHang();
            khToAdd.HoKH = txtHoKH.Text;
            khToAdd.TenKH = txtTenKH.Text;
            if (rdbNamKH.Checked == true)
            {
                khToAdd.GioiTinh = "Nam";
            }
            else
            {
                khToAdd.GioiTinh = "Nữ";
            }
            khToAdd.DiaChi = txtDiaChiKH.Text;
            khToAdd.DienThoai = txtSdtKH.Text;

            khBUS.AddKHBUS(khToAdd);
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txtHoKH.Text != "" || txtTenKH.Text != "" || txtDiaChiKH.Text != "" || txtSdtKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Thêm một khách hàng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddKH();
                        LoadKH();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    //Sửa KH
        private void UpdateKH()
        {
            KhachHang khToUpdate = new KhachHang();
            khToUpdate.MaKH = int.Parse(txtMaKH.Text);
            khToUpdate.HoKH = txtHoKH.Text;
            khToUpdate.TenKH = txtTenKH.Text;
            if (rdbNamKH.Checked == true)
            {
                khToUpdate.GioiTinh = "Nam";
            }
            else
            {
                khToUpdate.GioiTinh = "Nữ";
            }
            khToUpdate.DiaChi = txtDiaChiKH.Text;
            khToUpdate.DienThoai = txtSdtKH.Text;

            khBUS.UpdateKHBUS(khToUpdate);
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa khách hàng. " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateKH();
                        LoadKH();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khách hàng muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tìm KH
        private void txtTimKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKH_Click(sender, e);
            }
        }

        private void txtTimKH_Click(object sender, EventArgs e)
        {
            txtTimKH.Text = "";
            txtTimKH.ForeColor = Color.Black;
        }

        private void SearchKH()
        {
            if (rdbTimMaKH.Checked == true)
            {
                int key = int.Parse(txtTimKH.Text);
                dgvKH.DataSource = khBUS.SearchMaKHBUS(key);
            }
            else
            {
                string key = txtTimKH.Text;
                dgvKH.DataSource = khBUS.SearchTenKHBUS(key);
            }

        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            if (txtTimKH.Text != "" && txtTimKH.Text != "Nhập từ khóa............")
            {
                SearchKH();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Button

        private void btnQLy_Click(object sender, EventArgs e)
        {
            fDangNhapQuanLy f = new fDangNhapQuanLy();
            f.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    fDangNhap f = new fDangNhap();
                    f.Show();
                    this.Hide();
                    break;
                default:
                    break;
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan();
            f.Show();
            this.Hide();
        }

        #endregion

        #region Sản phẩm

        private void txtTimSP_Click(object sender, EventArgs e)
        {
            txtTimSP.Text = "";
            txtTimSP.ForeColor = Color.Black;
        }

        private void txtTimSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimSP_Click(sender, e);
            }
        }

        private void SearchSP()
        {

            if (rdbTimMaSP.Checked)
            {
                int key = int.Parse(txtTimSP.Text);
                dgvSP.DataSource = spBUS.SearchMaSPBUS(key);
            }
            else
            {
                string key = txtTimSP.Text;
                dgvSP.DataSource = spBUS.SearchTenSPBUS(key);
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if (txtTimSP.Text != "" && txtTimSP.Text != "Nhập từ khóa............")
            {
                SearchSP();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Hóa đơn

        //Hien thi 
        private void tabDatHang_Click(object sender, EventArgs e)
        {
            dgvSP.DataSource = spBUS.LoadSPBUS();

            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
            dtpNgayDatHang.Value = DateTime.Now;
            dtpNgayGiaoHang.Value = DateTime.Now;
            LoadHD();
        }

        private void LoadHD()
        {
            dgvHD.AutoGenerateColumns = false;
            dgvHD.DataSource = hdBUS.LoadHDBUS();
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaHD.Text = dgvHD.Rows[row].Cells[0].Value.ToString();
                cbMaKHang.Text = dgvHD.Rows[row].Cells[1].Value.ToString();
                cbMaNVien.Text = dgvHD.Rows[row].Cells[2].Value.ToString();
                dtpNgayDatHang.Value = DateTime.Parse(dgvHD.Rows[row].Cells[3].Value.ToString());
                dtpNgayGiaoHang.Value = DateTime.Parse(dgvHD.Rows[row].Cells[4].Value.ToString());

                cbMaSPham.Text = dgvHD.Rows[row].Cells[5].Value.ToString();
                txtGiaBan.Text = dgvHD.Rows[row].Cells[6].Value.ToString();
                txtSoLuong.Text = dgvHD.Rows[row].Cells[7].Value.ToString();
                txtGiamGia.Text = dgvHD.Rows[row].Cells[8].Value.ToString();
                txtThanhTien.Text = dgvHD.Rows[row].Cells[9].Value.ToString();
            }
        }

        private void cbMaKHang_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                KhachHang k = cb.SelectedValue as KhachHang;
                txtTenKHang.Text = (k.HoKH + " " + k.TenKH).ToString();
            }
        }

        private void cbMaNVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                NhanVien nv = cb.SelectedValue as NhanVien;
                txtTenNVien.Text = (nv.HoNV + " " + nv.TenNV).ToString();
            }
        }

        private void cbMaSPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                SanPham sp = cb.SelectedValue as SanPham;
                txtTenSPham.Text = sp.TenSP.ToString();
                txtGiaBan.Text = (sp.DonGia + sp.DonGia * 10/100).ToString();
            }
        }

    //Them
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "" && int.Parse(txtSoLuong.Text) > 0
                && txtGiamGia.Text != "" && double.Parse(txtGiamGia.Text) >= 0)
            {
                double a, b, c;
                a = double.Parse(txtGiaBan.Text);
                b = double.Parse(txtSoLuong.Text);
                c = double.Parse(txtGiamGia.Text);
                txtThanhTien.Text = (a * b - (a * b * c / 100)).ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin."
                    + "\n Số lượng phải lớn hơn 0."
                    + "\n Giảm giá phải lớn hơn hoặc bằng 0.");
            }
        }

        private void AddHD()
        {
            HoaDon hd = new HoaDon();
            hd.MaKH = int.Parse(cbMaKHang.Text);
            hd.MaNV = int.Parse(cbMaNVien.Text);
            hd.NgayDatHang = dtpNgayDatHang.Value;
            hd.NgayGiaoHang = dtpNgayGiaoHang.Value;

            ChiTietHD cthd = new ChiTietHD();
            cthd.MaSP = int.Parse(cbMaSPham.Text);
            cthd.GiaBan = decimal.Parse(txtGiaBan.Text);
            cthd.SoLuong = int.Parse(txtSoLuong.Text);
            cthd.GiamGia = double.Parse(txtGiamGia.Text);
            cthd.ThanhTien = decimal.Parse(txtThanhTien.Text);

            hdBUS.AddHDBUS(hd, cthd);
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (dtpNgayGiaoHang.Value.Date > dtpNgayDatHang.Value.Date 
                && txtSoLuong.Text != "" && txtThanhTien.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn lập hóa đơn mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        if (hdBUS.KtraConHangBUS(int.Parse(cbMaSPham.Text)) == 0)
                        {
                            AddHD();
                            LoadHD();
                            MessageBox.Show("Lập hóa đơn thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Rất tiếc, sản phẩm này tạm hết hàng.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.\nLưu ý ngày giao hàng phải luôn sau ngày đặt hàng 1 ngày.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    //Xoa HD
        private void DeleteHD()
        {
            int id = int.Parse(txtMaHD.Text);
            hdBUS.DeleteHDBUS(id);
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn " + txtMaHD.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteHD();
                        LoadHD();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn hóa đơn muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Sua HD
        private void UpdateHD()
        {
            HoaDon hd = new HoaDon();
            hd.MaHD = int.Parse(txtMaHD.Text);
            hd.MaNV = int.Parse(cbMaNVien.Text);
            hd.MaKH = int.Parse(cbMaKHang.Text);
            hd.NgayDatHang = dtpNgayDatHang.Value;
            hd.NgayGiaoHang = dtpNgayGiaoHang.Value;

            ChiTietHD cthd = new ChiTietHD();
            cthd.MaHD = int.Parse(txtMaHD.Text);
            cthd.MaSP = int.Parse(cbMaSPham.Text);
            cthd.GiaBan = decimal.Parse(txtGiaBan.Text);
            cthd.SoLuong = int.Parse(txtSoLuong.Text);
            cthd.GiamGia = double.Parse(txtGiamGia.Text);
            cthd.ThanhTien = decimal.Parse(txtThanhTien.Text);

            hdBUS.UpdateHDBUS(hd, cthd);
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa hóa đơn " + txtMaHD.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateHD();
                        LoadHD();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn hóa đơn muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim HD
        private void txtTimHD_Click(object sender, EventArgs e)
        {
            txtTimHD.Text = "";
            txtTimHD.ForeColor = Color.Black;
        }

        private void txtTimHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimHD_Click(sender, e);
            }
        }

        private void SearchHD()
        {
            if (rdbTimMaHD.Checked)
            {
                int maHD = int.Parse(txtTimHD.Text);
                dgvHD.DataSource = hdBUS.SearchMaHDBUS(maHD);
            }
            else
            {
                int maKH = int.Parse(txtTimHD.Text);
                dgvHD.DataSource = hdBUS.SearchMaHDBUS(maKH);
            }
        }

        private void btnTimHD_Click(object sender, EventArgs e)
        {
            if (txtTimHD.Text != "" && txtTimHD.Text != "Nhập từ khóa............")
            {
                SearchHD();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
