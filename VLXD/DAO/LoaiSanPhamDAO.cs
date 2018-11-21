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

    }
}
