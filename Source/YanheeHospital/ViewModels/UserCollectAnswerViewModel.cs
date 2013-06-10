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

        public UserCollectAnswerViewModel()
        {
            GenderDictionary = EnumHelper.ConvertEnumToDictionary(typeof(Gender));
            DinnerDictionary = EnumHelper.ConvertEnumToDictionary(typeof(Dinner));
        }

        public bool IsUserAuthenticated { get; set; }
        public User User { get; set; }
        public UserAnswer UserAnswer { get; set; }

        public Dictionary<int, string> GenderDictionary { get; set; }
        public Dictionary<int, string> DinnerDictionary { get; set; }

    }
}