using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task Send(string to, string subject, string body)
        {
            // create message
            var message = new MailMessage();
            message.From = new MailAddress("csharpp0@gmail.com", "HMS App");
            message.Subject = subject;
            message.Body = body;
            message.To.Add(new MailAddress(to));
            message.IsBodyHtml = false;

            try
            {
                var emailClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("csharpp0@gmail.com", "rwmfsvvmeomvaati")
                };

                await emailClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
