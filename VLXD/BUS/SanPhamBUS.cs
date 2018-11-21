using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO.Entity;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO spDAO = new SanPhamDAO();

        public List<SanPham> LoadSPBUS()
        {
            return spDAO.LoadSPDAO();
        }
        public void AddSPBUS(SanPham sp)
        {
            spDAO.AddSPDAO(sp);
        }
        public void DeleteSPBUS(int id)
        {
            spDAO.DeleteSPDAO(id);
        }
        public void UpdateSPBUS(SanPham spToUpdate)
        {
            spDAO.UpdateSPDAO(spToUpdate);
        }
    }
}
