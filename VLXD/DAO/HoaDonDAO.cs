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
    }
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
}
