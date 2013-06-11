using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace YanheeHospital.Helpers
{
    public static class DateTimeHelper
    {

        public static int TimeZoneOffset { get; set; }

        public static DateTime ToDefaultTargetGmtTime(this DateTime dateTime)
        {
            var gmtTime = dateTime.ToUniversalTime();
            var targetTime = gmtTime.AddHours(TimeZoneOffset);
            return targetTime;
        }


        internal static void SetTimeZoneOffSet()
        {
            var timeZoneOffsetString = ConfigurationManager.AppSettings["TimeZoneOffset"];
            var timeZoneOffset = 0;
            if (int.TryParse(timeZoneOffsetString, out timeZoneOffset))
            {
                TimeZoneOffset = timeZoneOffset;
            }

        }
    }
}