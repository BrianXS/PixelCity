using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Web.Data.ViewModels.AbstractViewModels;
using Web.Util.Attributes;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingOnboardingRequest : IPictureVM
    {
        [Required]
        public string Names { get; set; }
        
        [Required]
        public string Lastnames { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required, VerifyContentType]
        public IFormFile Picture { get; set; }
    }
}