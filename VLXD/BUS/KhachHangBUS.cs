using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO.Entity;

namespace BUS
{
    public class KhachHangBUS
    {
        KhachHangDAO khDAO = new KhachHangDAO();

        public List<KhachHang> LoadKHBUS()
        {
            return khDAO.LoadKHDAO();
        }
        public void AddKHBUS(KhachHang kh)
        {
            khDAO.AddKHDAO(kh);
        }

        public void DeleteKHBUS(int id)
        {
            khDAO.DeleteKHDAO(id);
        }
        public void UpdateKHBUS(KhachHang khToUpdate)
        {
            khDAO.UpdateKHDAO(khToUpdate);
        }
        public List<KhachHang> SearchMaKHBUS(int key)
        {
            return khDAO.SearchMaKHDAO(key);
        }

        public List<KhachHang> SearchTenKHBUS(string key)
        {
            return khDAO.SearchTenKHDAO(key);
        }
        
    }
}
