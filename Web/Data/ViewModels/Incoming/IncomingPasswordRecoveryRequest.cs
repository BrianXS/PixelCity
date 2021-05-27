using System.ComponentModel.DataAnnotations;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingPasswordRecoveryRequest
    {
        [Required]
        public string Username { get; set; }
    }
}