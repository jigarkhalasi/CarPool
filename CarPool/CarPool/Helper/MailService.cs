using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace CarPool.Helper
{
    public class MailService
    {
        public static async Task<bool> SendMail(string toAddress, CarPool.Helper.ApplicationConstant.EmailType emailType, string guid, string bodyData = "", string subjectData = "")
        {
            return await Task.Run(() =>
            {
                String userName = "info@rize2occasion.com";
                String password = "Wecare@123";
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(new MailAddress("jigs.prince78@gmail.com"));
                msg.From = new MailAddress(userName);
                msg.Subject = "Test Office 365 Account";
                msg.Body = "Testing email using Office 365 account.";
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.office365.com";
                client.Credentials = new System.Net.NetworkCredential(userName, password);
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(msg);

                //MailMessage message = new MailMessage();



                //SmtpClient smtpClient = new SmtpClient();

                //string smtpHost = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                //string smtpUser = ConfigurationManager.AppSettings["SmtpUser"].ToString();
                //string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"].ToString();

                //string subject = string.Empty;
                //string body = string.Empty;
                //string mailUrl = string.Empty;

                //message.From = new MailAddress(smtpUser, "MyWeb Site");
                //message.To.Add(new MailAddress(toAddress));


                ////try
                ////{


                ////    //message.Bcc.Add(ConfigurationManager.AppSettings["EmailBccAddress"].ToString());

                ////    message.IsBodyHtml = true;
                ////    message.Headers.Add("Content-Type", "content=text/html; charset=\"UTF-8\"");
                ////    switch (emailType)
                ////    {
                ////        case Astha.Models.ApplicationConstant.EmailType.VerifyEmail:
                ////            subject = "Email Verification";
                ////            mailUrl = ConfigurationManager.AppSettings["VerifyEmailUrl"].ToString();
                ////            var body1 = new StringBuilder();

                ////            if (toAddress.Contains("gmail.com"))
                ////            {
                ////                body = @"<b>Click the link below to verify your email address. After successful verification, our support staff will reach out to you for further details on the course and payment.</b> <br/><br/><br/> <a target='_blank' href='" + mailUrl + "/" + guid + "/" + toAddress + "'>Verify Email</a>";
                ////            }
                ////            else
                ////            {
                ////                body = @"<b>Copy Paste the link below to verify your email address. After successful verification, our support staff will reach out to you for further details on the course and payment.</b> <br/><br/><br/> " + mailUrl + "/" + guid + "/" + toAddress + "";
                ////            }

                ////            break;
                ////        case Astha.Models.ApplicationConstant.EmailType.ForgotPassword:
                ////            subject = "Reset Password";
                ////            mailUrl = ConfigurationManager.AppSettings["ForgotPasswordUrl"].ToString();
                ////            body = @"<b>Click the link below to reset your password</b> <br/><br/> <a target='_blank' href='" + mailUrl + "/" + guid + "/" + toAddress + "'>Reset Password</a>";
                ////            break;
                ////        case Astha.Models.ApplicationConstant.EmailType.ResetPassword:
                ////            subject = "Password Changed";
                ////            mailUrl = "dummy";
                ////            body = "<b>Password changed successfully.</b>";
                ////            break;

                ////        case Astha.Models.ApplicationConstant.EmailType.Registration:
                ////            subject = "New Register User";
                ////            mailUrl = "regisetr";
                ////            body = bodyData;
                ////            break;
                ////        default:
                ////            break;
                ////    }

                //    message.Subject = subject;
                //    message.Body = body;

                //    smtpClient.Host = smtpHost;   // We use gmail as our smtp client
                //    smtpClient.Port = 587;
                //    smtpClient.EnableSsl = true;
                //    smtpClient.UseDefaultCredentials = true;
                //    smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);

                //    //if (!string.IsNullOrWhiteSpace(subject) && !string.IsNullOrWhiteSpace(body) && !string.IsNullOrWhiteSpace(mailUrl))
                //   // {
                //        smtpClient.Send(message);
                //        return true;
                //   // }
                ////}
                ////catch
                ////{
                ////    throw;
                ////}

                return false;
            });
        }
    }
}