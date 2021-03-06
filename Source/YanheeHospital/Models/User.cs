﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YanheeHospital.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage="请输入姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入邮箱")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "请输入正确的邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }

        public Nullable<bool> IsInvitationEmailSent { get; set; }

        public Nullable<DateTime> InvitationEmailSentTime { get; set; }

        public Nullable<bool> IsAnswered { get; set; }

        public Nullable<DateTime> AnswerTime { get; set; }
    }
}