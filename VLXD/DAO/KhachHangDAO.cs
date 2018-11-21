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
        
    }
}
