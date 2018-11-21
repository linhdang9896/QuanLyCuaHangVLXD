using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class LoaiSanPhamDAO
    {
        VLXD db = new VLXD();

        public List<LoaiSanPham> LoadLoaiSPDAO()
        {
            return db.LoaiSanPham.ToList();
        }
        public int KtraTrung(string id)
        {
            var ktr = db.LoaiSanPham.Find(id);
            if (ktr == null)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public void AddLoaiSP(LoaiSanPham loai)
        {
            // change
            db.LoaiSanPham.Add(loai);
            db.SaveChanges();
        }
        public void DeleteLoaiSPDAO(int id)
        {
            LoaiSanPham loai = db.LoaiSanPham.Find(id);
            db.LoaiSanPham.Remove(loai);
            db.SaveChanges();
        }
        public void UpdateLoaiSPDAO(LoaiSanPham loaiToUpdate)
        {
            LoaiSanPham loai = db.LoaiSanPham.Find(loaiToUpdate.MaLoaiSP);
            loai.MaLoaiSP = loaiToUpdate.MaLoaiSP;
            loai.TenLoai = loaiToUpdate.TenLoai;
            db.SaveChanges();
        }
    }
}
