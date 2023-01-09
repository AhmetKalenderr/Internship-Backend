using InternShipApi.Core;
using InternShipApi.Services.Utility;
using System;
using System.Net;
using System.Net.Mail;

namespace Appointment.Services.Utility
{
    public class SendMail
    {
        public void SendVerifiedMails(string toAddress)
        {
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;

                sc.Credentials = new NetworkCredential("1160606005@nku.edu.tr", "A1588HMEt");

                MailMessage message = new MailMessage();
                message.From = new MailAddress("1160606005@nku.edu.tr", "RANDEVU");

                message.To.Add(toAddress);

                message.Subject = "MAİL DOĞRULAMA";
                message.IsBodyHtml = true;
                Cryption cry = new Cryption();
                string verifyAddress = "http://localhost:3000/mailVerified?token=" + cry.Encrypt(toAddress);
                message.Body = $@"<a href =""{verifyAddress}""> Doğrula </a>";
                sc.Send(message);
            }
            catch (Exception e )
            {
                throw e;
            }
        }
    }
}
