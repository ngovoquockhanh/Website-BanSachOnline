using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class TongThanhToanController : Controller
    {
        // GET: TongThanhToan
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()
        {
            return View();
        }
  
    }
}