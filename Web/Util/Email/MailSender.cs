using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Web.Data.Entities;

namespace Web.Util.Email
{
    public static class MailSender
    {
        public static async Task Execute(string sendTo, 
            string recipientName, 
            string sentFrom, 
            string senderName, 
            string mailSubject, 
            string plainContent,
            string richContent)
        {
            var apiKey = Environment.GetEnvironmentVariable("TEMPORAL_KEY");
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(sentFrom, senderName);
            var to = new EmailAddress(sendTo, recipientName);
            
            var msg = MailHelper
                .CreateSingleEmail(from, to, mailSubject, plainContent, richContent);
            
            var response = await client.SendEmailAsync(msg);
        }

        public static async Task SendConfirmationEmail(string sendTo, string token, string username)
        {
            var emailContent = "";
            
            await Execute(sendTo, sendTo, Constants.Global.EmailAddress, Constants.Global.SenderName, 
                "PixelCity - Verifica tu cuenta", emailContent, ConfirmationEmailText(token, username));
        }
        
        public static async Task SendPasswordRecoveryEmail(string sendTo, string token, string username)
        {
            var emailContent = "";
            
            await Execute(sendTo, sendTo, Constants.Global.EmailAddress, Constants.Global.SenderName, 
                "PixelCity - Cambia tu contraseña", emailContent, PasswordRecoveryEmailText(token, username));
        }
        
        public static async Task SendUsernameRecoveryEmail(string sendTo, string username)
        {
            var emailContent = "";
            
            await Execute(sendTo, sendTo, Constants.Global.EmailAddress, Constants.Global.SenderName, 
                "PixelCity - Tu nombre de usuario es " + username, emailContent, UsernameRecoveryEmailText(username));
        }

        private static string ConfirmationEmailText(string token, string username)
        {
            return File
                .ReadAllText(Directory.GetCurrentDirectory() + "/Util/Email/Templates/ConfirmEmail.html", Encoding.UTF8)
                .Replace("<a href=\"#\"", $"<a href=\"https://localhost:5001/confirm?Username={username}&Token={token}\"");
        }
        
        private static string PasswordRecoveryEmailText(string token, string username)
        {
            return File
                .ReadAllText(Directory.GetCurrentDirectory() + "/Util/Email/Templates/RecoverEmail.html", Encoding.UTF8)
                .Replace("<a href=\"#\"", $"<a href=\"https://localhost:5001/password-recovery?UserName={username}&Token={token}\"");
        }
        
        private static string UsernameRecoveryEmailText(string username)
        {
            return File
                .ReadAllText(Directory.GetCurrentDirectory() + "/Util/Email/Templates/RecoverUsername.html", Encoding.UTF8)
                .Replace("Lince-Placeholder", username)
                .Replace("<a href=\"#\"", "<a href=\"https://localhost:5001/login\"");
        }
    }
}