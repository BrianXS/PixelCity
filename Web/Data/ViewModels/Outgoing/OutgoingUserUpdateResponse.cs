using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Web.Data.ViewModels.Outgoing
{
    public class OutgoingUserUpdateResponse
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime BirthDate { get; set; }
        public string Biography { get; set; }
        
        public string Picture { get; set; }
        
        public string FacebookUsername  { get; set; }
        public string TwitterUsername   { get; set; }
        public string InstagramUsername { get; set; }
        public string YoutubeUsername   { get; set; }
        public string LinkedinUsername  { get; set; }
    }
}