using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class NhaSanXuatDAO
    {
        VLXD db = new VLXD();

        public List<NhaSanXuat> LoadNSXDAO()
        {
            return db.NhaSanXuat.ToList();
        }
        public void AddNSX(NhaSanXuat nsx)
        {
            db.NhaSanXuat.Add(nsx);
            db.SaveChanges();
        }
        public void DeleteNSXDAO(int id)
        {
            NhaSanXuat nsx = db.NhaSanXuat.Find(id);
            db.NhaSanXuat.Remove(nsx);
            db.SaveChanges();
        }
        
    }
}
