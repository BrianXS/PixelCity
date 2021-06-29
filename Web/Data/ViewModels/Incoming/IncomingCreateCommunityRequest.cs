using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Web.Data.ViewModels.AbstractViewModels;
using Web.Util.Attributes;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingCreateCommunityRequest : IPictureVM
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Url { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required, VerifyContentType]
        public IFormFile Picture { get; set; }
    }
}