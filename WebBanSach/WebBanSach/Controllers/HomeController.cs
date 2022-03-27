using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;
using PagedList;
using PagedList.Mvc;
using System.Configuration;

namespace WebBanSach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            //tạo biến số sản phẩm trên trang
            int pageSize = 12;
            //tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.Saches.Where(n =>n.Moi==1).OrderBy(n => n.GiaBan).ToPagedList(pageNumber,pageSize));
        }
     
    }
}