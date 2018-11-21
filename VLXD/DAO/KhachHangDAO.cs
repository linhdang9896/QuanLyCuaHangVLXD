using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class KhachHangDAO
    {
        VLXD db = new VLXD();

        public List<KhachHang> LoadKHDAO()
        {
            return db.KhachHang.ToList();
        }

        
    }
}
