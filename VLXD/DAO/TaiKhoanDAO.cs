using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Entity;
namespace DAO
{
    public class TaiKhoanDAO
    {
        VLXD db;
        public TaiKhoanDAO()
        {
            db = new VLXD();
        }

        public int DangNhapDAO(string uName, string pass)
        {
        
            var user = db.TaiKhoan
                .Where(p => p.TenTaiKhoan == uName)
                .FirstOrDefault();

            if (user != null)
            {
                if (user.MatKhau == pass)
                {
                    if (user.ChucVu == "Quản lý")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return -2;
                }
           }
           else
           {
                return -1;

           }
        }

    }
}
