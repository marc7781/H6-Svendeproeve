using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using ApiDBlayer;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using DbModels;

namespace ApiRepository
{
    public class MailRepository
    {
        Database db;
        // Email account credentials
        string senderEmail = "simontestprojekt@gmail.com";  
        string senderPassword = "Xua33ubf?";       
        string smtpHost = "smtp.gmail.com";         
        int smtpPort = 587; // SMTP port (587 for TLS, 465 for SSL)
        public MailRepository()
        {
            db = new Database();
        }
        public async Task<bool> SendOrderTakenAsync(Order order)
        {
            DtoUser owner = await GetOwnersFromIdAsync(order.Id);
            if(owner != null)
            {
                string subject = $"Your order of {order.Description} has been accepted";
                string body = $"Hej {owner.UserInfo.Name}, en chauffør har taget imod et af dine opslag.";

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false 
                };

                mailMessage.To.Add(owner.UserInfo.Email);

                if (await SendMailAsync(mailMessage))
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> SendOrderCompleteAsync(Order order)
        {
            DtoUser owner = await GetOwnersFromIdAsync(order.Id);
            if (owner != null)
            {
                string subject = $"Your order of {order.Description} has been completet";
                string body = $"Hej {owner.UserInfo.Name}, en af dine ordre er blevet leveret.";

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(owner.UserInfo.Email);

                if (await SendMailAsync(mailMessage)) 
                {
                    return true;
                }
            }
            return false;
        }
        private async Task<bool> SendMailAsync(MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private async Task<DtoUser> GetOwnersFromIdAsync(int ownerId)
        {
            DtoUser owner;
            try
            {
                owner = await db.Users.Where(x => x.Id == ownerId).Include(y => y.UserInfo).FirstOrDefaultAsync();
            }
            catch
            {
                owner = null;
            }
            return owner;
        }
    }
}
