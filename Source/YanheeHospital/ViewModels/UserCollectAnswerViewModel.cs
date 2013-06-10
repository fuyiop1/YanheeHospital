using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YanheeHospital.Models;
using YanheeHospital.Helpers;

namespace YanheeHospital.ViewModels
{
    public class UserCollectAnswerViewModel
    {
        public int UserBirthdateYear { get; set; }
        public int UserBirthdateMonth { get; set; }
        public int UserBirthdateDay { get; set; }

        public UserCollectAnswerViewModel()
        {
            GenderDictionary = EnumHelper.ConvertEnumToDictionary(typeof(Gender));
            DinnerDictionary = EnumHelper.ConvertEnumToDictionary(typeof(Dinner));
        }

        public bool IsUserAuthenticated { get; set; }
        public bool IsAdminViewAnswer { get; set; }
        public User User { get; set; }
        public UserAnswer UserAnswer { get; set; }

        public Dictionary<int, string> GenderDictionary { get; set; }
        public Dictionary<int, string> DinnerDictionary { get; set; }

    }
}