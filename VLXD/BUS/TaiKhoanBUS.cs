using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using DTO.Entity;
namespace BUS
{
    public class TaiKhoanBUS
    {
        TaiKhoanDAO userDAO = new TaiKhoanDAO();

        public int DangNhapBUS(string uName, string pass)
        {
            return userDAO.DangNhapDAO(uName, pass);
        }

    }
}
