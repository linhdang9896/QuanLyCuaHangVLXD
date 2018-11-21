using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_ProductCategory
    {
        LoaiSanPhamBUS lspBUS;
        LoaiSanPham lsp;
        [TestMethod]
        public void Test_AddLoaiSP_Suscess()
        {
            lspBUS = new LoaiSanPhamBUS();
            Assert.AreEqual(6, lspBUS.LoadLoaiSPBUS().Count);

            lsp = new LoaiSanPham();
            lsp.TenLoai = "lspTest";
            lspBUS.AddLoaiSPBUS(lsp);

            Assert.AreEqual(7, lspBUS.LoadLoaiSPBUS().Count);
        }

        [TestMethod]
        public void Test_UpdateLoaiSP_Suscess()
        {
            lsp = new LoaiSanPham();
            lsp.MaLoaiSP = 5;
            lsp.TenLoai = "Thép";
            
            lspBUS = new LoaiSanPhamBUS();
            Assert.AreEqual(0, lspBUS.SearchTenLoaiSPBUS(lsp.TenLoai).Count);

            lspBUS.UpdateLoaiSPBUS(lsp);

            Assert.AreEqual(1, lspBUS.SearchTenLoaiSPBUS(lsp.TenLoai).Count);
        }
        [TestMethod]
        public void Test_DeleteLoaiSP_Success()
        {
            lspBUS = new LoaiSanPhamBUS();
            Assert.AreEqual(7, lspBUS.LoadLoaiSPBUS().Count);
            lspBUS.DeleteLoaiSPBUS(7);
            Assert.AreEqual(6, lspBUS.LoadLoaiSPBUS().Count);
        }

        [TestMethod]
        public void Test_SearchMaLoaiSP_Suscess()
        {
            lspBUS = new LoaiSanPhamBUS();

            Assert.AreEqual(1, lspBUS.SearchMaLoaiSPBUS(1).Count);
        }
        [TestMethod]
        public void Test_SearchMaLoaiSP_Fail()
        {
            lspBUS = new LoaiSanPhamBUS();

            Assert.AreEqual(0, lspBUS.SearchMaLoaiSPBUS(100).Count);
        }

        [TestMethod]
        public void Test_SearchTenLoaiSP_Suscess()
        {
            lspBUS = new LoaiSanPhamBUS();

            Assert.AreEqual(1, lspBUS.SearchTenLoaiSPBUS("Gạch").Count);
        }

        [TestMethod]
        public void Test_SearchTenLoaiSP_Fail()
        {
            lspBUS = new LoaiSanPhamBUS();

            Assert.AreEqual(0, lspBUS.SearchTenLoaiSPBUS("Tinh tinh").Count);
        }
    }
}
