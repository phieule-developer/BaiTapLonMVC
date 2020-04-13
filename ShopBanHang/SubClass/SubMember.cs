using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopBanHang.SubClass
{
    public class SubMember
    {
        public string ID_Member { get; set; }
        public string Name_Member { get; set; }

        public string Phone_Member { get; set; }
        public string Address { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        
        public string CheckBox { get; set; }
        [NotMapped]
        [Compare("Password",ErrorMessage ="Mật khẩu và xác nhận mật khẩu không trùng nhau")]
        public string ConfirmPassword { get; set; }
    }
}