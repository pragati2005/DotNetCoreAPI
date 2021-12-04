using MimeKit;
using SendEmail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using SendEmail.Repository;


namespace SendEmail.Repository
{
    public class EmailSender : IEmailSender
    {

        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        //public void SendEmail(Message message)
        //{
        //    var emailMessage = CreateEmailMessage(message);
        //    Send(emailMessage);
        //}
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        //private void Send(MimeMessage mailMessage)
        //{
        //    using (var client = new MailKit.Net.Smtp.SmtpClient())
        //    {
        //        try
        //        {
        //            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
        //            client.AuthenticationMechanisms.Remove("XOAUTH2");
        //            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

        //            client.Send(mailMessage);
        //        }
        //        catch (Exception ex)
        //        {
        //            //log an error message or throw an exception or both.
        //            throw new InvalidOperationException(ex.Message);
        //        }
        //        finally
        //        {
        //            client.Disconnect(true);
        //            client.Dispose();
        //        }
        //    }
        //}


        async Task IEmailSender.SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);
            await SendAsync(mailMessage);

        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}





   