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

        
    }
}
