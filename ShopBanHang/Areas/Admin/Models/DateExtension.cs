using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Areas.Admin.Models
{
    public static class DateExtension
    {
        public static DateTime startdayOfweek(this DateTime dt, DayOfWeek day)
        {
            int diff = dt.DayOfWeek - day;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
    }
}