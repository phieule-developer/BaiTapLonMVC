using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ShopBanHang.Database;
using ShopBanHang.Models;
using ShopBanHang.SubClass;

namespace ShopBanHang.App_Start
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Admin, SubAdmin>();
                cfg.CreateMap<SubAdmin, Admin>();
                cfg.CreateMap<Member, SubMember>();
                cfg.CreateMap<SubMember, Member>();
                cfg.CreateMap<Cartt, Order_Detail>();
            });

        }
    }
}