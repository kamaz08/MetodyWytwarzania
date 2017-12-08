using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Sledzto.Track
{
    public class Sender
    {
        private static async Task SendAsync(String message, String email)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.To.Add(new MailAddress(email));

            mailMsg.From = new MailAddress("sledzto@pracadorywczatest.aspnet.pl", "sledz - nie odpisuj");

            mailMsg.Subject = "Zmiana";
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message));

            SmtpClient smtpClient = new SmtpClient("poczta.dcsweb.pl", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sledzto@pracadorywczatest.aspnet.pl", "ZAQ!2wsx");
            smtpClient.Credentials = credentials;
            try
            {
                await smtpClient.SendMailAsync(mailMsg);
            }
            catch (Exception e)
            {

            }

        }

        public static async void SendEmailAsync(String message, List<String> users)
        {
            foreach (string email in users)
                await SendAsync(message, email);
        }
    }
}