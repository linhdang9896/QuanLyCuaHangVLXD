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
        public void UpdateSPDAO(SanPham spToUpdate)
        {
            SanPham sp = db.SanPham.Find(spToUpdate.MaSP);

            sp.TenSP = spToUpdate.TenSP;
            sp.SoLuongTon = spToUpdate.SoLuongTon;
            sp.DonGia = spToUpdate.DonGia;
            sp.DonViTinh = spToUpdate.DonViTinh;
            sp.MoTa = spToUpdate.MoTa;
            sp.HinhAnh = spToUpdate.HinhAnh;
            sp.MaLoaiSP = spToUpdate.MaLoaiSP;
            sp.MaNSX = spToUpdate.MaNSX;

            db.SaveChanges();
        }
        public List<SanPham> SearchMaSPDAO(int key)
        {
            List<SanPham> result = new List<SanPham>();
            result = db.SanPham.Where(p => p.MaSP == key).ToList();
            return result;
        }

        public List<SanPham> SearchTenSPDAO(string key)
        {
            List<SanPham> result = new List<SanPham>();
            result = db.SanPham.Where(p => p.TenSP == key).ToList();
            return result;
        }
        
    }
}
