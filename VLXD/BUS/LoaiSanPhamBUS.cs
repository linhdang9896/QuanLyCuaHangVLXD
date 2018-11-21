using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO.Entity;

namespace BUS
{
    public class LoaiSanPhamBUS
    {
        LoaiSanPhamDAO loaiSPDAO = new LoaiSanPhamDAO();

        public List<LoaiSanPham> LoadLoaiSPBUS()
        {
            return loaiSPDAO.LoadLoaiSPDAO();
        }
        public int KtraTrungMaLoaiBUS(string id)
        {
            return loaiSPDAO.KtraTrung(id);
        }

        public void AddLoaiSPBUS(LoaiSanPham loai)
        {
            loaiSPDAO.AddLoaiSP(loai);
        }
        public void DeleteLoaiSPBUS(int id)
        {
            loaiSPDAO.DeleteLoaiSPDAO(id);
        }

        public void UpdateLoaiSPBUS(LoaiSanPham loaiToUpdate)
        {
            loaiSPDAO.UpdateLoaiSPDAO(loaiToUpdate);
        }
    }
}
