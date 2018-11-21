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
using DTO;

namespace VLXD
{
    public partial class fQuanLy : Form
    {
        public fQuanLy()
        {
            InitializeComponent();
        }

        private void fQuanLy_Load(object sender, EventArgs e)
        {
            LoadNV();
            LoadSP();
            LoadKH();
            LoadLoaiSP();
            LoadUser();
            LoadThongKe();
            LoadHD();
            LoadNSX();

            cbMaNV.DataSource = nvBUS.LoadNVBUS();
            cbMaNV.DisplayMember = "MaNV";

            cbMaKH.DataSource = khBUS.LoadKHBUS();
            cbMaKH.DisplayMember = "MaKH";

            cbMaNVien.DataSource = nvBUS.LoadNVBUS();
            cbMaNVien.DisplayMember = "MaNV";

            cbMaSP.DataSource = spBUS.LoadSPBUS();
            cbMaSP.DisplayMember = "MaSP";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    fDangNhap f = new fDangNhap();
                    f.Show();
                    this.Hide();
                    break;
                default:
                    break;
            }
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            fDatHang f = new fDatHang();
            f.Show();
            this.Hide();
        }

        #region NhanVien
        NhanVienBUS nvBUS = new NhanVienBUS();

        private void LoadNV()
        {
            dgvNV.AutoGenerateColumns = false;
            dgvNV.DataSource = nvBUS.LoadNVBUS();
        }

        private void tabNV_Click(object sender, EventArgs e)
        {
            LoadNV();
            txtMaNV.Text = "";
            txtHoNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChiNV.Text = "";
            txtSdtNV.Text = "";
            txtTimNV.Text = "";
            dtpNgaySinhNV.Value = new DateTime(1998, 1, 1);
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNV.Text = dgvNV.Rows[row].Cells[0].Value.ToString();
                txtHoNV.Text = dgvNV.Rows[row].Cells[1].Value.ToString();
                txtTenNV.Text = dgvNV.Rows[row].Cells[2].Value.ToString();

                if (dgvNV.Rows[row].Cells[3].Value.ToString() == "Nam")
                {
                    rdbNamNV.Checked = true;
                }
                else
                {
                    rdbNuNV.Checked = true;
                }

                dtpNgaySinhNV.Value = DateTime.Parse(dgvNV.Rows[row].Cells[4].Value.ToString());
                txtDiaChiNV.Text = dgvNV.Rows[row].Cells[5].Value.ToString();
                txtSdtNV.Text = dgvNV.Rows[row].Cells[6].Value.ToString();
            }
        }

    //Them Nhan Vien
        private void AddNV()
        {
            NhanVien nv = new NhanVien();
            nv.HoNV = txtHoNV.Text;
            nv.TenNV = txtTenNV.Text;
            if (rdbNamNV.Checked)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.NgaySinh = dtpNgaySinhNV.Value;
            nv.DiaChi = txtDiaChiNV.Text;
            nv.DienThoai = txtSdtNV.Text;

            nvBUS.AddNVBUS(nv);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtHoNV.Text != "" && txtTenNV.Text != "" && txtDiaChiNV.Text != "" && txtSdtNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một nhân viên mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddNV();
                        LoadNV();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
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

    //Xoa Nhan Vien
        private void DeleteNV()
        {
            int id = int.Parse(txtMaNV.Text);
            nvBUS.DeleteNVBUS(id);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteNV();
                        LoadNV();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhân viên muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Sua Nhan Vien
        private void UpdateNV()
        {
            NhanVien nvToUpdate = new NhanVien();
            nvToUpdate.MaNV = int.Parse(txtMaNV.Text);
            nvToUpdate.HoNV = txtHoNV.Text;
            nvToUpdate.TenNV = txtTenNV.Text;
            if (rdbNamNV.Checked == true)
            {
                nvToUpdate.GioiTinh = "Nam";
            }
            else
            {
                nvToUpdate.GioiTinh = "Nữ";
            }
            nvToUpdate.NgaySinh = dtpNgaySinhNV.Value;
            nvToUpdate.DiaChi = txtDiaChiNV.Text;
            nvToUpdate.DienThoai = txtSdtNV.Text;

            nvBUS.UpdateNVBUS(nvToUpdate);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa nhân viên " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateNV();
                        LoadNV();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhân viên muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim Nhan Vien
        private void txtTimNV_Click(object sender, EventArgs e)
        {
            txtTimNV.Text = "";
            txtTimNV.ForeColor = Color.Black;
        }

        private void txtTimNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimNV_Click(sender, e);
            }
        }

        private void SearchNV()
        {
            if (rdbTimMaNV.Checked)
            {
                int maNV = int.Parse(txtTimNV.Text);
                dgvNV.DataSource = nvBUS.SearchMaNVBUS(maNV);
            }
            else
            {
                string tenNV = txtTimNV.Text;
                dgvNV.DataSource = nvBUS.SearchTenNVBUS(tenNV);
            }
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            if (txtTimNV.Text != "" && txtTimNV.Text != "Nhập từ khóa............")
            {
                SearchNV();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region SanPham
        SanPhamBUS spBUS = new SanPhamBUS();

    //Hien thi San Pham
        private void LoadSP()
        {
            dgvSP.AutoGenerateColumns = false;
            dgvSP.DataSource = spBUS.LoadSPBUS();
        }

        private void tabSP_Click(object sender, EventArgs e)
        {
            LoadSP();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuongTon.Text = "";
            txtDonGia.Text = "";
            txtDonViTinh.Text = "";
            txtMaLoaiSP.Text = "";
            txtMoTa.Text = "";
            txtNSX.Text = "";
            txtTimSP.Text = "";
            picSP.Image = null;
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaSP.Text = dgvSP.Rows[row].Cells[0].Value.ToString();
                txtTenSP.Text = dgvSP.Rows[row].Cells[1].Value.ToString();
                txtSoLuongTon.Text = dgvSP.Rows[row].Cells[2].Value.ToString();
                txtDonGia.Text = dgvSP.Rows[row].Cells[3].Value.ToString();
                txtDonViTinh.Text = dgvSP.Rows[row].Cells[4].Value.ToString();
                txtMaLoaiSP.Text = dgvSP.Rows[row].Cells[6].Value.ToString();

                if (dgvSP.Rows[row].Cells[5].Value != null)
                {
                    txtMoTa.Text = dgvSP.Rows[row].Cells[5].Value.ToString();
                }
                else
                {
                    txtMoTa.Text = "";
                }

                if (dgvSP.Rows[row].Cells[7].Value.ToString() != "")
                {
                    picSP.Image = new Bitmap(Application.StartupPath + dgvSP.Rows[row].Cells[7].Value.ToString());
                }
                else
                {
                    picSP.Image = null;
                }

                if (dgvSP.Rows[row].Cells[8].Value != null)
                {
                    txtNSX.Text = dgvSP.Rows[row].Cells[8].Value.ToString();
                }
                else
                {
                    txtNSX.Text = "";
                }
            }
        }

    //Them San Pham
        private void AddSP()
        {
            SanPham spToAdd = new SanPham();
            spToAdd.TenSP = txtTenSP.Text;
            spToAdd.SoLuongTon = int.Parse(txtSoLuongTon.Text);
            spToAdd.DonGia = decimal.Parse(txtDonGia.Text);
            spToAdd.DonViTinh = txtDonViTinh.Text;
            spToAdd.MoTa = txtMoTa.Text;
            spToAdd.MaLoaiSP = int.Parse(txtMaLoaiSP.Text);
            spToAdd.HinhAnh = txtHinhSP.Text;
            spToAdd.MaNSX = int.Parse(txtNSX.Text);

            spBUS.AddSPBUS(spToAdd);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text != "" && txtDonViTinh.Text != "" && txtMaLoaiSP.Text != ""
                && txtNSX.Text != "" && txtDonGia.Text != "" && txtSoLuongTon.Text != ""
                && decimal.Parse(txtSoLuongTon.Text) >= 0 && decimal.Parse(txtDonGia.Text) > 0)
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một sản phẩm mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddSP();
                        LoadSP();
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

    //Xoa San Pham
        private void DeleteSP()
        {
            int id = int.Parse(txtMaSP.Text);
            spBUS.DeleteSPBUS(id);
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + txtMaSP.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteSP();
                        LoadSP();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn sản phẩm muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Sua San Pham
        private void UpdateSP()
        {
            SanPham spToUpdate = new SanPham();

            spToUpdate.MaSP = int.Parse(txtMaSP.Text);
            spToUpdate.TenSP = txtTenSP.Text;
            spToUpdate.SoLuongTon = int.Parse(txtSoLuongTon.Text);
            spToUpdate.DonGia = decimal.Parse(txtDonGia.Text);
            spToUpdate.DonViTinh = txtDonViTinh.Text;
            spToUpdate.MoTa = txtMoTa.Text;
            spToUpdate.MaLoaiSP = int.Parse(txtMaLoaiSP.Text);
            spToUpdate.HinhAnh = txtHinhSP.Text;
            spToUpdate.MaNSX = int.Parse(txtNSX.Text);

            spBUS.UpdateSPBUS(spToUpdate);
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "" && decimal.Parse(txtDonGia.Text) > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa sản phẩm " + txtMaSP.Text,
                    "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                 
                    case DialogResult.OK:
                        UpdateSP();
                        LoadSP();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn sản phẩm muốn sửa thông tin.\nLưu ý đơn giá phải lớn hơn 0, số lượng tồn lớn hơn hoặc bằng 0.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim San Pham
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

        #region KhachHang
        KhachHangBUS khBUS = new KhachHangBUS();

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
            if (txtHoKH.Text != "" && txtTenKH.Text != "" && txtDiaChiKH.Text != "" && txtSdtKH.Text != "")
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

        //Xóa KH
        private void DeleteKH()
        {
            int id = int.Parse(txtMaKH.Text);
            khBUS.DeleteKHBUS(id);
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteKH();
                        LoadKH();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khách hàng muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (rdbTimMaKH.Checked)
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

        #region LoaiSanPham
        LoaiSanPhamBUS loaiSPBUS = new LoaiSanPhamBUS();

    //Hien thi Loai SP
        private void LoadLoaiSP()
        {
            dgvLoai.AutoGenerateColumns = false;
            dgvLoai.DataSource = loaiSPBUS.LoadLoaiSPBUS();
        }

        private void tabLoaiSP_Click(object sender, EventArgs e)
        {
            LoadLoaiSP();
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
        }

        private void dgvLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaLoai.Text = dgvLoai.Rows[row].Cells[0].Value.ToString();
                txtTenLoai.Text = dgvLoai.Rows[row].Cells[1].Value.ToString();
            }
        }

    //Them Loai SP
        private void AddLoaiSP()
        {
            LoaiSanPham loaiToAdd = new LoaiSanPham();
            loaiToAdd.TenLoai = txtTenLoai.Text;

            loaiSPBUS.AddLoaiSPBUS(loaiToAdd);
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một loại sản phẩm mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddLoaiSP();
                        LoadLoaiSP();
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

    //Xoa Loai SP
        private void DeleteLoaiSP()
        {
            int id = int.Parse(txtMaLoai.Text);
            loaiSPBUS.DeleteLoaiSPBUS(id);
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm?" + txtMaLoai.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteLoaiSP();
                        LoadLoaiSP();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn loại sản phẩm muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    //Sua Loai SP
        private void UpdateLoaiSP()
        {
            LoaiSanPham loaiToUpdate = new LoaiSanPham();
            loaiToUpdate.MaLoaiSP = int.Parse(txtMaLoai.Text);
            loaiToUpdate.TenLoai = txtTenLoai.Text;

            loaiSPBUS.UpdateLoaiSPBUS(loaiToUpdate);
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa loại sản phẩm " + txtMaLoai.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateLoaiSP();
                        LoadLoaiSP();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn loại sản phẩm muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim Loai SP
        private void SearchLoaiSP()
        {
            if (rdbTimMaLoai.Checked)
            {
                int key = int.Parse(txtTimLoai.Text);
                dgvLoai.DataSource = loaiSPBUS.SearchMaLoaiSPBUS(key);
            }
            else
            {
                string key = txtTimLoai.Text;
                dgvLoai.DataSource = loaiSPBUS.SearchTenLoaiSPBUS(key);
            }
        }

        private void btnTimLoai_Click(object sender, EventArgs e)
        {
            if (txtTimLoai.Text != "" && txtTimLoai.Text != "Nhập từ khóa............")
            {
                SearchLoaiSP();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTimLoai_Click(object sender, EventArgs e)
        {
            txtTimLoai.Text = "";
            txtTimLoai.ForeColor = Color.Black;
        }

        private void txtTimLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimLoai_Click(sender, e);
            }
        }
        #endregion

        #region TaiKhoan

        TaiKhoanBUS userBUS = new TaiKhoanBUS();
    //Hien thi 
        private void LoadUser()
        {
            dgvUser.AutoGenerateColumns = false;
            dgvUser.DataSource = userBUS.LoadUserBUS();
        }

        private void tabUser_Click(object sender, EventArgs e)
        {
            txtMaTaiKhoan.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        int eyeClick = 1;
        private void lbXemMatKhau_Click(object sender, EventArgs e)
        {
            if (eyeClick % 2 != 0)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
            eyeClick++;
        }

        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaTaiKhoan.Text = dgvUser.Rows[row].Cells[0].Value.ToString();
                txtTenDangNhap.Text = dgvUser.Rows[row].Cells[1].Value.ToString();
                txtMatKhau.Text = dgvUser.Rows[row].Cells[2].Value.ToString();
                cbChucVu.Text = dgvUser.Rows[row].Cells[3].Value.ToString();
                cbMaNVien.Text = dgvUser.Rows[row].Cells[4].Value.ToString();
            }
        }

    //Them Tai Khoan
        private void AddUser()
        {
            TaiKhoan userToAdd = new TaiKhoan();
            userToAdd.TenTaiKhoan = txtTenDangNhap.Text;
            userToAdd.MatKhau = txtMatKhau.Text;
            userToAdd.ChucVu = cbChucVu.Text;
            userToAdd.MaNV = int.Parse(cbMaNVien.Text);

            userBUS.AddUserBUS(userToAdd);
        }

        private void btnThemUser_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "" && cbChucVu.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một tài khoản mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddUser();
                        LoadUser();
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

    //Xoa Tai Khoan
        private void DeleteUser()
        {
            int userId = int.Parse(txtMaTaiKhoan.Text);
            userBUS.DeleteUserBUS(userId);
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản." + txtTenDangNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteUser();
                        LoadUser();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn tài khoản muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Sua Tai Khoan
        private void UpdateUser()
        {
            TaiKhoan user = new TaiKhoan();
            user.MaTaiKhoan = int.Parse(txtMaTaiKhoan.Text);
            user.TenTaiKhoan = txtTenDangNhap.Text;
            user.MatKhau = txtMatKhau.Text;
            user.ChucVu = cbChucVu.Text;
            user.MaNV = int.Parse(cbMaNVien.Text);

            userBUS.UpdateUserBUS(user);
        }

        private void btnSuaUser_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa tài khoản." + txtTenDangNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateUser();
                        LoadUser();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn tài khoản muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim Tai Khoan
        private void SearchTaiKhoan()
        {
            if (rdbTimMaUser.Checked)
            {
                int key = int.Parse(txtTimUser.Text);
                dgvUser.DataSource = userBUS.SearchMaTaiKhoan(key);
            }
            else
            {
                string key = txtTimUser.Text;
                dgvUser.DataSource = userBUS.SearchTenTaiKhoan(key);
            }
        }

        private void btnTimUser_Click(object sender, EventArgs e)
        {
            if (txtTimUser.Text != "" && txtTimUser.Text != "Nhập từ khóa............")
            {
                SearchTaiKhoan();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTimUser_Click(object sender, EventArgs e)
        {
            txtTimLoai.Text = "";
            txtTimLoai.ForeColor = Color.Black;
        }

        private void txtTimUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimUser_Click(sender, e);
            }
        }
        #endregion

        #region Thống kê
        HoaDonBUS hdBUS = new HoaDonBUS();

        private void tabThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            dgvThongKe.AutoGenerateColumns = false;
            dgvThongKe.DataSource = hdBUS.LoadHDBUS();
        }

        private void SearchNgayDatHang()
        {
            DateTime ngayBD, ngayKT;
            ngayBD = dtpNgayBD.Value;
            ngayKT = dtpNgayKT.Value;
            var r = hdBUS.SearchNgayDatHangBUS(ngayBD, ngayKT);
            dgvThongKe.DataSource = hdBUS.SearchNgayDatHangBUS(ngayBD, ngayKT);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtpNgayBD.Value < dtpNgayKT.Value)
            {
                SearchNgayDatHang();
            }
            else
            {
                MessageBox.Show("Hãy kiểm tra xem ngày bắt đầu có trước ngày kết thúc không.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Hóa đơn
        ChiTietHDBUS cthdBUS = new ChiTietHDBUS();
    //Hien thi 
        private void tabHD_Click(object sender, EventArgs e)
        {
            LoadHD();
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            dtpNgayDatHang.Value = DateTime.Now;
            dtpNgayGiaoHang.Value = DateTime.Now;
        }

        private void LoadHD()
        {
            dgvHD.AutoGenerateColumns = false;
            dgvHD.DataSource = hdBUS.LoadHDBUS();
        }

        private void cbMaKH_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                KhachHang k = cb.SelectedValue as KhachHang;
                txtTenKHang.Text = (k.HoKH + " " + k.TenKH).ToString();
            }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                NhanVien nv = cb.SelectedValue as NhanVien;
                txtTenNVien.Text = (nv.HoNV + " " + nv.TenNV).ToString();
            }
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                SanPham sp = cb.SelectedValue as SanPham;
                txtTenSPham.Text = sp.TenSP.ToString();
                txtGiaBan.Text = (sp.DonGia + sp.DonGia * 10/100).ToString();
            }
        }

        string oldMaSP = null;
        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaHD.Text = dgvHD.Rows[row].Cells[0].Value.ToString();
                cbMaKH.Text = dgvHD.Rows[row].Cells[1].Value.ToString();
                cbMaNV.Text = dgvHD.Rows[row].Cells[2].Value.ToString();
                dtpNgayDatHang.Value = DateTime.Parse(dgvHD.Rows[row].Cells[3].Value.ToString());
                dtpNgayGiaoHang.Value = DateTime.Parse(dgvHD.Rows[row].Cells[4].Value.ToString());
                oldMaSP = cbMaSP.Text = dgvHD.Rows[row].Cells[5].Value.ToString();
                txtGiaBan.Text = dgvHD.Rows[row].Cells[6].Value.ToString();
                txtSoLuong.Text = dgvHD.Rows[row].Cells[7].Value.ToString();
                txtGiamGia.Text = dgvHD.Rows[row].Cells[8].Value.ToString();
                txtThanhTien.Text = dgvHD.Rows[row].Cells[9].Value.ToString();
            }
        }

    //Them HD
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
            hd.MaKH = int.Parse(cbMaKH.Text);
            hd.MaNV = int.Parse(cbMaNV.Text);
            hd.NgayDatHang = dtpNgayDatHang.Value;
            hd.NgayGiaoHang = dtpNgayGiaoHang.Value;

            ChiTietHD cthd = new ChiTietHD();
            cthd.MaSP = int.Parse(cbMaSP.Text);
            cthd.GiaBan = decimal.Parse(txtGiaBan.Text);
            cthd.SoLuong  = int.Parse(txtSoLuong.Text);
            cthd.GiamGia  = double.Parse(txtGiamGia.Text);
            cthd.ThanhTien = decimal.Parse(txtThanhTien.Text);

            hdBUS.AddHDBUS(hd, cthd);
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (dtpNgayGiaoHang.Value.Date > dtpNgayDatHang.Value.Date 
                && txtMaHD.Text == "" && txtGiamGia.Text != ""
                && txtSoLuong.Text != "" && int.Parse(txtSoLuong.Text) > 0
                && txtThanhTien.Text != "" && int.Parse(txtThanhTien.Text) > 0)
            {
                DialogResult result = MessageBox.Show("Bạn muốn lập hóa đơn mới?",
                    "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;

                    case DialogResult.OK:
                        if (hdBUS.KtraConHangBUS(int.Parse(txtMaSP.Text)) == 0)
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
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin."
                +"\nLưu ý ngày giao hàng phải luôn sau ngày đặt hàng 1 ngày,"
                +"số lượng và thành tiền phải lớn hơn 0 và % giảm giá phải lớn hơn hoặc bằng 0.",
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
            hd.MaNV = int.Parse(cbMaNV.Text);
            hd.MaKH = int.Parse(cbMaKH.Text);
            hd.NgayDatHang = dtpNgayDatHang.Value;
            hd.NgayGiaoHang = dtpNgayGiaoHang.Value;

            ChiTietHD cthd = new ChiTietHD();
            cthd.MaHD = int.Parse(txtMaHD.Text);
            cthd.GiaBan = decimal.Parse(txtGiaBan.Text);
            cthd.SoLuong = int.Parse(txtSoLuong.Text);
            cthd.GiamGia = double.Parse(txtGiamGia.Text);
            cthd.ThanhTien = decimal.Parse(txtThanhTien.Text);

            hdBUS.UpdateHDBUS(hd, cthd);
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "" && int.Parse(oldMaSP) == int.Parse(cbMaSP.Text))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa hóa đơn " + txtMaHD.Text + "\nLưu ý không thể đổi sản phẩm khác.",
                    "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
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
                MessageBox.Show("Hãy chọn hóa đơn muốn sửa thông tin.\nLưu ý không thể đổi thành sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgvHD.DataSource = hdBUS.SearchMaKHBUS(maKH);
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

        #region Nhà sản xuất

        NhaSanXuatBUS nsxBUS = new NhaSanXuatBUS();

    //Hien thi
        private void tabNSX_Click(object sender, EventArgs e)
        {
            txtMaNSX.Text = "";
            txtTenNSX.Text = "";
            txtDiaChiNSX.Text = "";
            txtDienThoaiNSX.Text = "";
            txtTimNSX.Text = "";
            LoadNSX();
        }

        private void LoadNSX()
        {
            dgvNSX.AutoGenerateColumns = false;
            dgvNSX.DataSource = nsxBUS.LoadNSXBUS();
        }

        private void dgvNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNSX.Text = dgvNSX.Rows[row].Cells[0].Value.ToString();
                txtTenNSX.Text = dgvNSX.Rows[row].Cells[1].Value.ToString();
                txtDiaChiNSX.Text = dgvNSX.Rows[row].Cells[2].Value.ToString();
                txtDienThoaiNSX.Text = dgvNSX.Rows[row].Cells[3].Value.ToString();
            }
        }

    //Them NSX
        private void AddNSX()
        {
            NhaSanXuat nsxToAdd = new NhaSanXuat();
            nsxToAdd.TenCongTyNSX = txtTenNSX.Text;
            nsxToAdd.DiaChiNSX = txtDiaChiNSX.Text;
            nsxToAdd.DienThoaiNSX = txtDienThoaiNSX.Text;

            nsxBUS.AddNSXBUS(nsxToAdd);
        }

        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            if (txtTenNSX.Text != "" && txtDiaChiNSX.Text != "" && txtDienThoaiNSX.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một nhà sản xuất mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddNSX();
                        LoadNSX();
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

    //Sua NSX
        private void UpdateNSX()
        {
            NhaSanXuat nsxToUpdate = new NhaSanXuat();
            nsxToUpdate.MaNSX = int.Parse(txtMaNSX.Text);
            nsxToUpdate.TenCongTyNSX = txtTenNSX.Text;
            nsxToUpdate.DiaChiNSX = txtDiaChiNSX.Text;
            nsxToUpdate.DienThoaiNSX = txtDienThoaiNSX.Text;

            nsxBUS.UpdateNSXBUS(nsxToUpdate);
        }

        private void btnSuaNSX_Click(object sender, EventArgs e)
        {
            if (txtMaNSX.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa nhà sản xuất " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateNSX();
                        LoadNSX();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhà sản xuất muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Xoa NSX
        private void DeleteNSX()
        {
            int id = int.Parse(txtMaNSX.Text);
            nsxBUS.DeleteNSXBUS(id);
        }

        private void btnXoaNSX_Click(object sender, EventArgs e)
        {
            if (txtMaNSX.Text != "")
            {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhà sản xuất" + txtMaNSX.Text+ "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteNSX();
                        LoadNSX();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhà sản xuất muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim NSX
        private void txtTimNSX_Click(object sender, EventArgs e)
        {
            txtTimNSX.Text = "";
            txtTimNSX.ForeColor = Color.Black;
        }

        private void txtTimNSX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimNSX_Click(sender, e);
            }
        }

        private void SearchNSX()
        {
            if (rdbMaNSX.Checked)
            {
                int key = int.Parse(txtTimNSX.Text);
                dgvNSX.DataSource = nsxBUS.SearchMaNSXBUS(key);
            }
            else
            {
                string key = txtTimNSX.Text;
                dgvNSX.DataSource = nsxBUS.SearchTenNSXBUS(key);
            }
        }

        private void btnTimNSX_Click(object sender, EventArgs e)
        {
            if (txtTimNSX.Text != "" && txtTimNSX.Text != "Nhập từ khóa............")
            {
                SearchNSX();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}