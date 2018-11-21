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

        
    }
}
