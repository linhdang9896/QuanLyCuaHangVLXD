using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Customer
    {
        KhachHangBUS khBUS;
        KhachHang kh;

        [TestMethod]
        public void Test_AddKhachHang_Suscess()
        {
            khBUS = new KhachHangBUS();
            Assert.AreEqual(10, khBUS.LoadKHBUS().Count);

            kh = new KhachHang();
            kh.HoKH = "Nguyễn Thị";
            kh.TenKH = "th";
            kh.GioiTinh = "Nu";
            kh.DiaChi = "123";
            kh.DienThoai = "321";
            khBUS.AddKHBUS(kh);

            Assert.AreEqual(11, khBUS.LoadKHBUS().Count);
        }

        [TestMethod]
        public void Test_UpdateKhachHang_Suscess()
        {
            kh = new KhachHang();
            kh.MaKH = 1011;
            kh.HoKH = "Nguyễn Thị";
            kh.TenKH = "Pass Test";
            kh.GioiTinh = "Nam";
            kh.DiaChi = "1234 Nguyễn Văn Linh";
            kh.DienThoai = "038123246";

            khBUS = new KhachHangBUS();
            Assert.AreEqual(0, khBUS.SearchTenKHBUS(kh.TenKH).Count);

            khBUS.UpdateKHBUS(kh);

            Assert.AreEqual(1, khBUS.SearchTenKHBUS(kh.TenKH).Count);
        }
    }
}
