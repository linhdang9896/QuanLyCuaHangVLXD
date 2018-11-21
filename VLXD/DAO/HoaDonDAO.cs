using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;
using DTO;

namespace DAO
{
    public class HoaDonDAO
    {
        VLXD db = new VLXD();

        public List<HD_CTHD> LoadHDDAO()
        {
            List<HD_CTHD> result = (from hd in db.HoaDon
                                    join cthd in db.ChiTietHD
                                    on hd.MaHD equals cthd.MaHD
                                    select new HD_CTHD(){
                                        MaHD =  hd.MaHD,
                                        MaKH = hd.MaKH,
                                        MaNV = hd.MaNV,
                                        NgayDatHang = hd.NgayDatHang,
                                        NgayGiaoHang = hd.NgayGiaoHang,
                                        MaSP = cthd.MaSP,
                                        GiaBan = cthd.GiaBan,
                                        SoLuong = cthd.SoLuong,
                                        GiamGia = cthd.GiamGia,
                                        ThanhTien = cthd.ThanhTien
                                    }).ToList();
            return result;
        }

        public int KtraConHangDAO(int maSPKtra)
        {
            SanPham spKtra = db.SanPham.Find(maSPKtra);
            if (spKtra.SoLuongTon > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public void AddHDDAO(HoaDon hd, ChiTietHD cthd)
        {
            db.HoaDon.Add(hd);
            db.SaveChanges();

            int idhd = hd.MaHD;
            cthd.MaHD = idhd;

            db.ChiTietHD.Add(cthd);
            db.SaveChanges();
        }

        public void DeleteHDDAO(int id)
        {
            ChiTietHD cthd = db.ChiTietHD.Where(p => p.MaHD == id).SingleOrDefault();
            db.ChiTietHD.Remove(cthd);
            db.SaveChanges(); 

            HoaDon hd = db.HoaDon.Find(id);
            db.HoaDon.Remove(hd);
            db.SaveChanges();
        }

        public void UpdateHDDAO(HoaDon hdToUpDate, ChiTietHD cthdToUpDate)
        {
            int id = hdToUpDate.MaHD;
            ChiTietHD cthd = db.ChiTietHD.Where(p => p.MaHD == id).SingleOrDefault();
            cthd.GiaBan = cthdToUpDate.GiaBan;
            cthd.SoLuong = cthdToUpDate.SoLuong;
            cthd.GiamGia = cthdToUpDate.GiamGia;
            cthd.ThanhTien = cthdToUpDate.ThanhTien;
            db.SaveChanges();

            HoaDon hd = db.HoaDon.Find(hdToUpDate.MaHD);
            hd.MaKH = hdToUpDate.MaKH;
            hd.MaNV = hdToUpDate.MaNV;
            hd.NgayDatHang = hdToUpDate.NgayDatHang;
            hd.NgayGiaoHang = hdToUpDate.NgayGiaoHang;
            db.SaveChanges();
        }

        public List<HD_CTHD> SearchMaHDDAO(int key)
        {
            List<HD_CTHD> result = (from hd in db.HoaDon
                                    join cthd in db.ChiTietHD
                                    on hd.MaHD equals cthd.MaHD
                                    where hd.MaHD == key
                                    select new HD_CTHD(){
                                        MaHD =  hd.MaHD,
                                        MaKH = hd.MaKH, 
                                        MaNV = hd.MaNV,
                                        NgayDatHang = hd.NgayDatHang,
                                        NgayGiaoHang = hd.NgayGiaoHang,
                                        MaSP = cthd.MaSP,
                                        GiaBan = cthd.GiaBan,
                                        SoLuong = cthd.SoLuong,
                                        GiamGia = cthd.GiamGia,
                                        ThanhTien = cthd.ThanhTien
                                    }).ToList();
            return result;
        }

        public List<HD_CTHD> SearchMaKHDAO(int key)
        {
            List<HD_CTHD> result = (from hd in db.HoaDon
                                    join cthd in db.ChiTietHD
                                    on hd.MaHD equals cthd.MaHD
                                    where hd.MaKH == key
                                    select new HD_CTHD(){
                                        MaHD =  hd.MaHD,
                                        MaKH = hd.MaKH, 
                                        MaNV = hd.MaNV,
                                        NgayDatHang = hd.NgayDatHang,
                                        NgayGiaoHang = hd.NgayGiaoHang,
                                        MaSP = cthd.MaSP,
                                        GiaBan = cthd.GiaBan,
                                        SoLuong = cthd.SoLuong,
                                        GiamGia = cthd.GiamGia,
                                        ThanhTien = cthd.ThanhTien
                                    }).ToList();
            return result;
        }

        public List<HD_CTHD> SearchNgayDatHangDAO(DateTime ngayBD, DateTime ngayKT)
        {
            List<HD_CTHD> result = (from hd in db.HoaDon
                                    join cthd in db.ChiTietHD
                                    on hd.MaHD equals cthd.MaHD
                                    where hd.NgayDatHang >= ngayBD && hd.NgayDatHang <= ngayKT
                                    select new HD_CTHD()
                                    {
                                        MaHD = hd.MaHD,
                                        MaKH = hd.MaKH,
                                        MaNV = hd.MaNV,
                                        NgayDatHang = hd.NgayDatHang,
                                        NgayGiaoHang = hd.NgayGiaoHang,
                                        MaSP = cthd.MaSP,
                                        GiaBan = cthd.GiaBan,
                                        SoLuong = cthd.SoLuong,
                                        GiamGia = cthd.GiamGia,
                                        ThanhTien = cthd.ThanhTien
                                    }).ToList();
            return result;
        }
    }
}
