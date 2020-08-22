using Bookswagon.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Bookswagon.Email
{
    public class Mailing
    {
        UserData data = new UserData();
        public void SendMail(string Subject, string contentBody)
        {
            MailMessage mail = new MailMessage();
            string FromEmail = data.email;
            string Password = data.password;
            string ToEmail = data.devmail;
            mail.From = new MailAddress(FromEmail);
            mail.To.Add(ToEmail);
            mail.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            mail.Body = contentBody;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(ConfigurationManager.AppSettings["Path"]));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(FromEmail, Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

    }
}
