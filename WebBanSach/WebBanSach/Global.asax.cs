using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebBanSach.Models;
namespace WebBanSach
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            Application["Songuoidangtruycap"] = 0;
            Application["SoHoaDon"] = 0;
            Application["Songuoidangtruycap"] = (int)Application["Songuoidangtruycap"] + 1;
            Application["SoHoaDon"] = (int)Application["SoHoaDon"] + 1;
        }

        protected void Session_Star()
        {
            Application.Lock(); //Đồng bộ hóa
            Application["Songuoidangtruycap"] = (int)Application["Songuoidangtruycap"] +1;
            Application["SoHoaDon"] = (int)Application["SoHoaDon"] + 1;
            Application.UnLock();
        }
        protected void Session_End()
        {
            Application.Lock(); //Đồng bộ hóa
          
          Application["SoHoaDon"] = (int)Application["SoHoaDon"] - 1;
          Application.UnLock();
        }
    }
}
