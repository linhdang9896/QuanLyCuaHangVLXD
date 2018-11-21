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

        
    }
}
