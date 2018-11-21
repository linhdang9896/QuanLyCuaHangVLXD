using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO.Entity;

namespace BUS
{
    public class ChiTietHDBUS
    {
        ChiTietHDDAO cthdDAO = new ChiTietHDDAO();

        public List<ChiTietHD> LoadChiTietHDBUS()
        {
            return cthdDAO.LoadChiTietHDDAO();
        }
        public void AddChiTietHDBUS(ChiTietHD hd)
        {
            cthdDAO.AddChiTietHDDAO(hd);
        }

        public void DeleteChiTietHDBUS(int maHD, int maSP)
        {
            cthdDAO.DeleteChiTietHDDAO(maHD, maSP);
        }
    }
}
