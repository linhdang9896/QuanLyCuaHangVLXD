using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Supplier
    {
        NhaSanXuatBUS nsxBUS;
        NhaSanXuat nsx;

        [TestMethod]
        public void Test_AddNSX_Suscess()
        {
            nsxBUS = new NhaSanXuatBUS();
            Assert.AreEqual(4, nsxBUS.LoadNSXBUS().Count);

            nsx = new NhaSanXuat();
            nsx.TenCongTyNSX = "nsxTest";
            nsx.DiaChiNSX = "1123 xyz";
            nsx.DienThoaiNSX = "012345";
            nsxBUS.AddNSXBUS(nsx);

            Assert.AreEqual(5, nsxBUS.LoadNSXBUS().Count);
        }

        [TestMethod]
        public void Test_UpdateNSX_Suscess()
        {
            nsx = new NhaSanXuat();
            nsx.MaNSX = 6;
            nsx.TenCongTyNSX = "nsxTestUpdate";
            
            nsxBUS = new NhaSanXuatBUS();
            Assert.AreEqual(0, nsxBUS.SearchTenNSXBUS(nsx.TenCongTyNSX).Count);

            nsxBUS.UpdateNSXBUS(nsx);

            Assert.AreEqual(1, nsxBUS.SearchTenNSXBUS(nsx.TenCongTyNSX).Count);
        }
        [TestMethod]
        public void Test_DeleteNSX_Success()
        {
            nsxBUS = new NhaSanXuatBUS();
            Assert.AreEqual(5, nsxBUS.LoadNSXBUS().Count);
            nsxBUS.DeleteNSXBUS(6);
            Assert.AreEqual(4, nsxBUS.LoadNSXBUS().Count);
        }

        [TestMethod]
        public void Test_SearchMaNSX_Suscess()
        {
            nsxBUS = new NhaSanXuatBUS();

            Assert.AreEqual(1, nsxBUS.SearchMaNSXBUS(1).Count);
        }
        [TestMethod]
        public void Test_SearchMaNSX_Fail()
        {
            nsxBUS = new NhaSanXuatBUS();

            Assert.AreEqual(0, nsxBUS.SearchMaNSXBUS(100).Count);
        }

        [TestMethod]
        public void Test_SearchTenNSX_Suscess()
        {
            nsxBUS = new NhaSanXuatBUS();

            Assert.AreEqual(1, nsxBUS.SearchTenNSXBUS("CÔNG TY TNHH GẠCH AN PHÚ GIA").Count);
        }
        [TestMethod]
        public void Test_SearchTenNSX_Fail()
        {
            nsxBUS = new NhaSanXuatBUS();

            Assert.AreEqual(0, nsxBUS.SearchTenNSXBUS("Tinh tinh").Count);
        }
    }
}
