using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO.Entity;

namespace BUS
{
    public class NhaSanXuatBUS
    {
        NhaSanXuatDAO nsxDAO = new NhaSanXuatDAO();

        public List<NhaSanXuat> LoadNSXBUS()
        {
            return nsxDAO.LoadNSXDAO();
        }
        public void AddNSXBUS(NhaSanXuat nsx)
        {
            nsxDAO.AddNSX(nsx);
        }

        public void DeleteNSXBUS(int id)
        {
            nsxDAO.DeleteNSXDAO(id);
        }
        public void UpdateNSXBUS(NhaSanXuat nsxToUpdate)
        {
            nsxDAO.UpdateNSXDAO(nsxToUpdate);
        }
        public List<NhaSanXuat> SearchMaNSXBUS(int key)
        {
            return nsxDAO.SearchMaNSXDAO(key);
        }

        public List<NhaSanXuat> SearchTenNSXBUS(string key)
        {
            return nsxDAO.SearchTenNSXDAO(key);
        }
    }
}
