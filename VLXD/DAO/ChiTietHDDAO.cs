using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class ChiTietHDDAO
    {
        VLXD db = new VLXD();

        public List<ChiTietHD> LoadChiTietHDDAO()
        {
            return db.ChiTietHD.ToList();
        }
    }
}
