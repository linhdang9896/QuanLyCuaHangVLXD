using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO.Entity;
using DTO;

namespace BUS
{
    public class HoaDonBUS
    {
        HoaDonDAO hdDAO = new HoaDonDAO();

        public List<HD_CTHD> LoadHDBUS()
        {
            return hdDAO.LoadHDDAO();
        }

    }
}
