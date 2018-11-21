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
    }
}
