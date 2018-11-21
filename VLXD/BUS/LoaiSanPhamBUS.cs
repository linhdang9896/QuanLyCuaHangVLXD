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

    }
}
