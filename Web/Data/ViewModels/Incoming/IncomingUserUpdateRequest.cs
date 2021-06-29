using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Web.Data.ViewModels.AbstractViewModels;
using Web.Util.Attributes;

namespace Web.Data.ViewModels.Incoming
{
    public class IncomingUserUpdateRequest : IPictureVM
    {
        [Required]
        public string Names { get; set; }
        
        [Required]
        public string LastNames { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [MaxLength(190)]
        public string Biography { get; set; }
        
        [VerifyContentType]
        public IFormFile Picture { get; set; }

        public string FacebookUsername  { get; set; }
        public string TwitterUsername   { get; set; }
        public string InstagramUsername { get; set; }
        public string YoutubeUsername   { get; set; }
        public string LinkedinUsername  { get; set; }
    }
}