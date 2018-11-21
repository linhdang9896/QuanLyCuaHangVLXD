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
        public void UpdateNSXDAO(NhaSanXuat nsxToUpdate)
        {
            NhaSanXuat nsx = db.NhaSanXuat.Find(nsxToUpdate.MaNSX);
            nsx.TenCongTyNSX = nsxToUpdate.TenCongTyNSX;
            nsx.DiaChiNSX = nsxToUpdate.DiaChiNSX;
            nsx.DienThoaiNSX = nsxToUpdate.DienThoaiNSX;
            db.SaveChanges();
        }
        
    }
}
