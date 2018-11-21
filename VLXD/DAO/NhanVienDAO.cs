using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class NhanVienDAO
    {
        VLXD db = new VLXD();

        public List<NhanVien> LoadNVDAO()
        {
            return db.NhanVien.ToList();
        }
        public void AddNVDAO(NhanVien nv)
        {
            db.NhanVien.Add(nv);
            db.SaveChanges();
        }

        public void DeleteNVDAO(int id)
        {
            NhanVien nv = db.NhanVien.Find(id);
            db.NhanVien.Remove(nv);
            db.SaveChanges();
        }
        public void UpdateNVDAO(NhanVien nvToUpDate)
        {
            NhanVien nv = db.NhanVien.Find(nvToUpDate.MaNV);
            nv.HoNV = nvToUpDate.HoNV;
            nv.TenNV = nvToUpDate.TenNV;
            nv.GioiTinh = nvToUpDate.GioiTinh;
            nv.NgaySinh = nvToUpDate.NgaySinh;
            nv.DiaChi = nvToUpDate.DiaChi;
            nv.DienThoai = nvToUpDate.DienThoai;
            db.SaveChanges();
        }
        public List<NhanVien> SearchMaNVDAO(int key)
        {
            List<NhanVien> result = new List<NhanVien>();
            result = db.NhanVien.Where(p => p.MaNV == key).ToList();
            return result;
        }

        public List<NhanVien> SearchTenNVDAO(string key)
        {
            List<NhanVien> result = new List<NhanVien>();
            result = db.NhanVien.Where(p => p.TenNV == key).ToList();
            return result;
        }
    }
}
