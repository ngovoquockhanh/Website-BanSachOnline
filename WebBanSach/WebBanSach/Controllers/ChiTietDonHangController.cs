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
    public class ChiTietDonHangController : Controller
    {
        private QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()
        {
            var ctdh = db.ChiTietDonHangs;

            return View(ctdh.ToList());

        }
        public ActionResult Details(int? id)
        {
            // Nếu không có người dùng có mã được truyền vào thì trả về trang báo lỗi
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Khai báo một người dùng theo mã
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Find(id);
            if (ctdh == null)
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
        public ActionResult Create([Bind(Include = "MaDonHang,MaSach,SoLuong,DonGia")]ChiTietDonHang ctdh)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonHangs.Add(ctdh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(ctdh);
        }


        // Chỉnh sửa người dùng
        // GET: Admin/Nguoidungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Find(id);
            if (ctdh == null)
            {
                return HttpNotFound();
            }

            return View(ctdh);
        }

        // POST: Admin/Nguoidungs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,MaSach,SoLuong,DonGia")] ChiTietDonHang ctdh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctdh).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ctdh);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Find(id);
            if (ctdh == null)
            {
                return HttpNotFound();
            }
            return View(ctdh);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Find(id);
            db.ChiTietDonHangs.Remove(ctdh);
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
