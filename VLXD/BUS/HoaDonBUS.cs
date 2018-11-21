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
        public int KtraConHangBUS(int maSPKtra)
        {
            return hdDAO.KtraConHangDAO(maSPKtra);
        }

        public void AddHDBUS(HoaDon hd,ChiTietHD cthd)
        {
            hdDAO.AddHDDAO(hd,cthd);
        }
         public void DeleteHDBUS(int id)
        {
            hdDAO.DeleteHDDAO(id);
        }

        public void UpdateHDBUS(HoaDon hdToUpDate, ChiTietHD cthdToUpdate)
        {
            hdDAO.UpdateHDDAO(hdToUpDate, cthdToUpdate);
        }
    }
}
