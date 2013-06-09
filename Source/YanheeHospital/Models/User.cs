using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YanheeHospital.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsInvitationEmailSent { get; set; }
        public Nullable<DateTime> InvitationEmailSentTime { get; set; }
        public Nullable<bool> IsAnswered { get; set; }
        public Nullable<DateTime> AnswerTime { get; set; }
    }
}