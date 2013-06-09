using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YanheeHospital.Models;

namespace YanheeHospital.ViewModels
{
    public class UserIndexViewModel
    {
        public List<User> Users { get; set; }

        public User CurrentUser { get; set; }
    }
}