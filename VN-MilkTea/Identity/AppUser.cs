using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VN_MilkTea.Identity
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
    }
}