using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class KhachHangDAO
    {
        VLXD db = new VLXD();

        public List<KhachHang> LoadKHDAO()
        {
            return db.KhachHang.ToList();
        }
        public void AddKHDAO(KhachHang kh)
        {
            db.KhachHang.Add(kh);
            db.SaveChanges();
        }

        public void DeleteKHDAO(int id)
        {
            KhachHang kh = db.KhachHang.Find(id);
            db.KhachHang.Remove(kh);
            db.SaveChanges();
        }
         public void UpdateKHDAO(KhachHang khToUpdate)
        {
            KhachHang kh = db.KhachHang.Find(khToUpdate.MaKH);
            kh.HoKH = khToUpdate.HoKH;
            kh.TenKH = khToUpdate.TenKH;
            kh.GioiTinh = khToUpdate.GioiTinh;
            kh.DiaChi = khToUpdate.DiaChi;
            kh.DienThoai = khToUpdate.DienThoai;
            db.SaveChanges();
        }
    }
}
