﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.DonHangs = new HashSet<DonHang>();
        }

        public int MaKH { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string HoTen { get; set; }
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string TaiKhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string MatKhau { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string DienThoai { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string GioiTinh { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<int> IDQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}