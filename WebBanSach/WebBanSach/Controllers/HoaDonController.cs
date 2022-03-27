using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        private QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()
        {
            var DonHang = db.DonHangs;

            return View(DonHang.ToList());
          
        }
        public ActionResult Details(int? id)
        {
            // Nếu không có người dùng có mã được truyền vào thì trả về trang báo lỗi
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Khai báo một người dùng theo mã
            DonHang donhang = db.DonHangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            // trả về trang chi tiết người dùng
            return View();
        }

        //// GET: Admin/Nguoidungs/Create
        public ActionResult Create()
        {
            
           return View();
        }

        //// POST: Admin/Nguoidungs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,TinhTrangGiaoHang,NgayGiao")] DonHang dh)
        {
         if (ModelState.IsValid)
            {
               db.DonHangs.Add(dh);
                db.SaveChanges();
               return RedirectToAction("Index");
           }

           
           return View(dh);
        }


        // Chỉnh sửa người dùng
        // GET: Admin/Nguoidungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dh = db.DonHangs.Find(id);
            if (dh == null)
            {
                return HttpNotFound();
            }
           
            return View(dh);
        }

        // POST: Admin/Nguoidungs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,TinhTrangGiaoHang,NgayGiao")] DonHang dh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dh).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(dh);
        }

        // Xoá người dùng 
        // GET: Admin/Nguoidungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           DonHang dh = db.DonHangs.Find(id);
            if (dh== null)
            {
                return HttpNotFound();
            }
            return View(dh);
        }

        // POST: Admin/Nguoidungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang dh = db.DonHangs.Find(id);
            db.DonHangs.Remove(dh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}