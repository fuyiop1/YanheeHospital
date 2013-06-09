using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YanheeHospital.Models;

namespace YanheeHospital.ViewModels
{
    public class UserCollectAnswerViewModel
    {
        public bool IsUserAuthenticated { get; set; }
        public User User { get; set; }
        public UserAnswer UserAnswer { get; set; }
    }
}