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

    }
}
