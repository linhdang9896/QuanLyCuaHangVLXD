using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO.Entity;

namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAO nvDAO = new NhanVienDAO();

        public List<NhanVien> LoadNVBUS()
        {
            return nvDAO.LoadNVDAO();
        }
        public void AddNVBUS(NhanVien nv)
        {
            nvDAO.AddNVDAO(nv);
        }

        public void DeleteNVBUS(int id)
        {
            nvDAO.DeleteNVDAO(id);
        }
        public void UpdateNVBUS(NhanVien nvToUpDate)
        {
            nvDAO.UpdateNVDAO(nvToUpDate);
        }
        public List<NhanVien> SearchMaNVBUS(int key)
        {
            return nvDAO.SearchMaNVDAO(key);
        }

        public List<NhanVien> SearchTenNVBUS(string key)
        {
            return nvDAO.SearchTenNVDAO(key);
        }
    }
}
