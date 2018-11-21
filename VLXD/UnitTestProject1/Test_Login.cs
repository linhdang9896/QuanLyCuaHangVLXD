using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Login
    {
        TaiKhoanBUS uBUS;
        [TestMethod]
        public void Test_LoginByNhanVien()
        {
            uBUS = new TaiKhoanBUS();

            int expected = 2;
            int actual = uBUS.DangNhapBUS("Tam", "123");

            Assert.AreEqual(expected, actual);
        }
    }
}