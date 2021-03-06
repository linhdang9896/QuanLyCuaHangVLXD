using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Product
    {
        SanPhamBUS spBUS;
        SanPham sp;

        [TestMethod]
        public void Test_AddSP_Suscess()
        {
            spBUS = new SanPhamBUS();
            Assert.AreEqual(13, spBUS.LoadSPBUS().Count);

            sp = new SanPham();
            sp.TenSP = "spTest";
            sp.SoLuongTon = 1;
            sp.DonGia = 10;
            sp.DonViTinh = "kg";
            sp.MoTa = "";
            sp.HinhAnh = "";
            sp.MaLoaiSP = 1;
            sp.MaNSX = 1;

            spBUS.AddSPBUS(sp);

            Assert.AreEqual(14, spBUS.LoadSPBUS().Count);
        }

        [TestMethod]
        public void Test_UpdateSP_Suscess()
        {
            sp = new SanPham();
            sp.MaSP = 17;
            sp.TenSP = "spTestUpdate";

            spBUS = new SanPhamBUS();
            Assert.AreEqual(0, spBUS.SearchTenSPBUS(sp.TenSP).Count);

            spBUS.UpdateSPBUS(sp);

            Assert.AreEqual(1, spBUS.SearchTenSPBUS(sp.TenSP).Count);
        }
        [TestMethod]
        public void Test_DeleteSP_Success()
        {
            spBUS = new SanPhamBUS();
            Assert.AreEqual(14, spBUS.LoadSPBUS().Count);
            spBUS.DeleteSPBUS(17);
            Assert.AreEqual(13, spBUS.LoadSPBUS().Count);
        }


        [TestMethod]
        public void Test_SearchMaSP_Suscess()
        {
            spBUS = new SanPhamBUS();

            Assert.AreEqual(1, spBUS.SearchMaSPBUS(2).Count);
        }
        [TestMethod]
        public void Test_SearchMaSP_Fail()
        {
            spBUS = new SanPhamBUS();

            Assert.AreEqual(0, spBUS.SearchMaSPBUS(100).Count);
        }

        [TestMethod]
        public void Test_SearchTenSP_Suscess()
        {
            spBUS = new SanPhamBUS();

            Assert.AreEqual(1, spBUS.SearchTenSPBUS("Đá xây").Count);
        }

        [TestMethod]
        public void Test_SearchTenSP_Fail()
        {
            spBUS = new SanPhamBUS();

            Assert.AreEqual(0, spBUS.SearchTenSPBUS("Tinh tinh").Count);
        }
    }
}
