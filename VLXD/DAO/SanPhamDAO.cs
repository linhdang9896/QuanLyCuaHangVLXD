using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class SanPhamDAO
    {
        VLXD db = new VLXD();

        public List<SanPham> LoadSPDAO()
        {
            return db.SanPham.ToList();
        }
        public void AddSPDAO(SanPham sp)
        {
            db.SanPham.Add(sp);
            db.SaveChanges();
        }

        public void DeleteSPDAO(int id)
        {
            SanPham sp = db.SanPham.Find(id);
            db.SanPham.Remove(sp);
            db.SaveChanges();
        }
        
    }
}
