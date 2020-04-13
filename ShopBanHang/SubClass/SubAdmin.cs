using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBanHang.SubClass
{
    public class SubAdmin
    {
        [StringLength(50)]
        public string ID_Admin { get; set; }

        [StringLength(50)]
        public string Name_Admin { get; set; }

        [StringLength(50)]
        public string Phone_Admin { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Password { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
        public string CheckBox { get; set; }
    }
}