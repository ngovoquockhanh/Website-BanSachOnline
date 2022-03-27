using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanSach.Models;

namespace WebBanSach.Models
{
    public class GioHang
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
         public string sAnhBia { get; set; }
        public double dDonGia { get; set; }

        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm Tạo Giỏ Hàng
        public GioHang(int MaSach)
        {
            iMaSach = MaSach;
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia =double.Parse( sach.GiaBan.ToString());
            iSoLuong = 1; 

        }
        
       
    }
}