using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class ThongkeController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: Thongke
        public ActionResult Index()
        {
            //lấy số người truy cập từ application được tạo
            ViewBag.Songuoidangtruycap = HttpContext.Application["Songuoidangtruycap"].ToString();
            
            ViewBag.TongDoanhThu = Thongketongdoanhthu();
            ViewBag.TongDDH = Thongkedonhang();
            return View();
        }
        public double Thongkedonhang()
        {
            double dh = db.DonHangs.Count();
            return dh;
        }
        public decimal Thongketongdoanhthu()
        {
            
            decimal TongDoanhThu = db.ChiTietDonHangs.Sum(n => n.SoLuong * n.DonGia).Value;
            return TongDoanhThu;
        }
        public decimal Thongketongdoanhthutheongay(int thang , int nam)
        {
            var listdh = db.DonHangs.Where(n => n.NgayDat.Value.Month == thang &&
            n.NgayDat.Value.Year == nam);
            decimal Tongtien = 0;
            foreach(var item in listdh)
            {
                Tongtien += decimal.Parse(item.ChiTietDonHangs.Sum(n => n.SoLuong * n.DonGia).Value.ToString());
            }
            return Tongtien;
        }
       
    }
}