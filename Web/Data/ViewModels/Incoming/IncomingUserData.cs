using System.ComponentModel.DataAnnotations;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingUserData
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}