using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using YanheeHospital.Models;

namespace YanheeHospital.Helpers
{
    public static class EmailHelper
    {
        private static readonly string SmtpAddress;
        private static readonly string SmtpPort;
        private static readonly NetworkCredential SmtpCredential;

        private static readonly string EmailSubject;
        private static readonly string EmailBody;
        private static readonly string FromEmailUser;

        static EmailHelper()
        {
            SmtpAddress = ConfigurationManager.AppSettings["SmtpAddress"];
            SmtpPort = ConfigurationManager.AppSettings["SmtpPort"];
            var smtpUser = ConfigurationManager.AppSettings["SmtpUser"];
            var smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            SmtpCredential = new NetworkCredential(smtpUser, smtpPassword);

            FromEmailUser = ConfigurationManager.AppSettings["FromEmailUser"];
            EmailSubject = ConfigurationManager.AppSettings["EmailSubject"];
            EmailBody = ConfigurationManager.AppSettings["EmailBody"];
        }

        public static bool SendEmail(User toUser) {
            var result = false;
            try
            {
                var smtpClient = new SmtpClient(SmtpAddress, Convert.ToInt32(SmtpPort));
                smtpClient.Credentials = SmtpCredential;

                var emailBody = string.Format(EmailBody, toUser.Name, toUser.Id, toUser.Password);
                var mailMessage = new MailMessage(FromEmailUser, toUser.Email, EmailSubject, emailBody);
                mailMessage.IsBodyHtml = true;

                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return result;
        }

    }
}