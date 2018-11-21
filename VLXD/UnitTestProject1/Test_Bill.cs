using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Bill
    {
        HoaDonBUS hdBUS;

        [TestMethod]
        public void Test_SearchMaHD_Suscess()
        {
            hdBUS = new HoaDonBUS();

            Assert.AreEqual(1, hdBUS.SearchMaHDBUS(1).Count);
        }

        [TestMethod]
        public void Test_SearchMaHD_Fail()
        {
            hdBUS = new HoaDonBUS();

            Assert.AreEqual(0, hdBUS.SearchMaHDBUS(0).Count);
        }
    }
}
