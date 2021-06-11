using System.ComponentModel.DataAnnotations;

namespace Web.Data.ViewModels.Outgoing
{
    public class OutgoingChangePasswordResponse
    {
        public string CurrentPassword { get; set; }
        
        [Compare("NewPasswordValidation")]
        public string NewPassword { get; set; }
        
        public string NewPasswordValidation { get; set; }
    }
}