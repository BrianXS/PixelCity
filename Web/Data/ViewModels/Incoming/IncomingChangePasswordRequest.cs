using System.ComponentModel.DataAnnotations;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingChangePasswordRequest
    {
        [Required]
        public string CurrentPassword { get; set; }
        
        [Required]
        [Compare("NewPasswordValidation")]
        public string NewPassword { get; set; }
        
        [Required]
        public string NewPasswordValidation { get; set; }
    }
}