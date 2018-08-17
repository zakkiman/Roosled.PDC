using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PDC.Web.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MailMessage(new MailAddress("ahmadzakki@gmail.com", "Ahmad Zakki"), new MailAddress(email));
            emailMessage.Subject = subject;
            emailMessage.Body = message;

            NetworkCredential cre = new NetworkCredential();
            cre.UserName = "ahmadzakki@gmail.com";
            cre.Password = "4hmadzakk1";
            using (var client = new SmtpClient())
            {
                client.Credentials = cre;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 468;
                client.UseDefaultCredentials = false;
                client.SendAsync(emailMessage, Guid.NewGuid().ToString());
            }
            return Task.CompletedTask;
        }
    }
}
