using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using WebBanSach.Models;
namespace WebBanSach.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
       QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: GioHang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> GioHangs = Session["GioHang"] as List<GioHang>;
            if (GioHangs == null)
            {
                GioHangs = new List<GioHang>();
                Session["GioHang"] = GioHangs;
            }
            return GioHangs;
        }

        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaSach, string strURL)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> GioHangs = LayGioHang();
            //Kiểm tra đã tồn tại trong session giỏ hàng chưa
            GioHang sanpham = GioHangs.Find(n => n.iMaSach == iMaSach);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                GioHangs.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int MaSP, FormCollection f)
        {

            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> GioHangs = LayGioHang();
            GioHang sanpham = GioHangs.SingleOrDefault(n => n.iMaSach == MaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int MaSP)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> GioHangs = LayGioHang();
            GioHang sanpham = GioHangs.SingleOrDefault(n => n.iMaSach == MaSP);
            if (sanpham != null)
            {
                GioHangs.RemoveAll(n => n.iMaSach == MaSP);
            }
            if (GioHangs.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> GioHangs = LayGioHang();

            return View(GioHangs);
        }
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int Tongsoluong = 0;
            List<GioHang> GioHangs = Session["GioHang"] as List<GioHang>;
            if (GioHangs != null)
            {
                Tongsoluong = GioHangs.Sum(n => n.iSoLuong);
            }
            return Tongsoluong;
        }
        //Tính tổng tiền
        private double TongTien()
        {
            double Tongtien = 0;
            List<GioHang> GioHangs = Session["GioHang"] as List<GioHang>;
            if (GioHangs != null)
            {
                Tongtien = GioHangs.Sum(n => n.ThanhTien);
            }
            return Tongtien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng view chỉnh sửa giỏ hàng cho người dùng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> GioHangs = LayGioHang();
            return View(GioHangs);
        }
        //Xây dựng chức năng đặt hàng
        public ActionResult DatHang(FormCollection collection)
        {
            //Kiểm tra đã đăng nhập chưa
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng 

            DonHang dh = new DonHang();
            KhachHang kh = (KhachHang)Session["use"];
            List<GioHang> gh = LayGioHang();
            dh.MaKH = kh.MaKH;
            dh.NgayDat = DateTime.Now;
            dh.TinhTrangGiaoHang = 0;
            dh.DaThanhToan = 0;
            db.DonHangs.Add(dh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = dh.MaDonHang;
                ctDH.MaSach = item.iMaSach;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (decimal)item.dDonGia;
                db.ChiTietDonHangs.Add(ctDH);
            }
            db.SaveChanges();

            return View();
        }
        public ActionResult Xacnhandonhang()
        {
          
            return View();
        }
    }
}