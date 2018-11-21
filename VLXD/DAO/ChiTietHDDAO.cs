using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class ChiTietHDDAO
    {
        VLXD db = new VLXD();

        public List<ChiTietHD> LoadChiTietHDDAO()
        {
            return db.ChiTietHD.ToList();
        }
        public void AddChiTietHDDAO(ChiTietHD cthd)
        {
            db.ChiTietHD.Add(cthd);
            db.SaveChanges();
        }

        public void DeleteChiTietHDDAO(int maHD, int maSP)
        {
            ChiTietHD cthd = db.ChiTietHD.Find(maHD, maSP);
            db.ChiTietHD.Remove(cthd);
            db.SaveChanges();
        }
        public void UpdateChiTietHDDAO(ChiTietHD cthdhdToUpDate)
        {
            ChiTietHD cthd = db.ChiTietHD.Find(cthdhdToUpDate.MaHD);
            cthd.MaHD = cthdhdToUpDate.MaHD;
            cthd.MaSP = cthdhdToUpDate.MaSP;
            cthd.GiaBan = cthdhdToUpDate.GiaBan;
            cthd.GiamGia = cthdhdToUpDate.GiamGia;
            cthd.ThanhTien = cthdhdToUpDate.ThanhTien;
            db.SaveChanges();
        }
        public List<ChiTietHD> SearchChiTietHD_MaHDDAO(int key)
        {
            List<ChiTietHD> result = new List<ChiTietHD>();
            result = db.ChiTietHD.Where(p => p.MaHD == key).ToList();
            return result;
        }

        public List<ChiTietHD> SearchChiTietHD_MaSPDAO(int key)
        {
            List<ChiTietHD> cthd = new List<ChiTietHD>();
            cthd = db.ChiTietHD.Where(p => p.MaSP == key).ToList();
            return cthd;
        }
    }
}
