using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Employee
    {
        NhanVienBUS nvBUS;
        NhanVien nv;

        [TestMethod]
        public void Test_LoginByNhanVien()
        {
            uBUS = new TaiKhoanBUS();

            int expected = 2;
            int actual = uBUS.DangNhapBUS("Tam", "123");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_LoginByQuanLy()
        {
            uBUS = new TaiKhoanBUS();

            int expected = 1;
            int actual = uBUS.DangNhapBUS("Long", "123");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_LoginWrongID()
        {
            uBUS = new TaiKhoanBUS();

            int expected = -1;
            int actual = uBUS.DangNhapBUS("LongLong", "123");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_LoginWrongPass()
        {
            uBUS = new TaiKhoanBUS();

            int expected = -2;
            int actual = uBUS.DangNhapBUS("Long", "321");

            Assert.AreEqual(expected, actual);
        }
    }
}
