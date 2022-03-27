using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;
namespace WebBanSach.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
        
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                ViewBag.ThongBao = "Chúc mừng bạn đã đăng ký thành công";

            }
            
            return View();

        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string TaiKhoan = f["txtTaiKhoan"].ToString();
            string MatKhau = f["txtMatKhau"].ToString();
            var islogin = db.KhachHangs.SingleOrDefault(x => x.TaiKhoan.Equals(TaiKhoan) && x.MatKhau.Equals(MatKhau));
            if (islogin != null)
            {
                if (TaiKhoan == "Admin")
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "QuanLySanPham/Home");
                }
                else
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Home");
                }
            }


            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();


        }
        public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index", "Home");

        }

    }
}
