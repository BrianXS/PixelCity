using System.ComponentModel.DataAnnotations;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingPasswordRecoveryData
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}