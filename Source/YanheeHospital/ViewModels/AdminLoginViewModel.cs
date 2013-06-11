using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YanheeHospital.Models;

namespace YanheeHospital.ViewModels
{
    public class AdminLoginViewModel
    {
        public string ReturnUrl { get; set; }
        public Admin Admin { get; set; }
        public bool IsRememberAccount { get; set; }
    }
}