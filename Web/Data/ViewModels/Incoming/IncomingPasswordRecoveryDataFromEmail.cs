using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingPasswordRecoveryDataFromEmail
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Token { get; set; }
    }
}