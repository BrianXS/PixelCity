using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Data.ViewModels.Outgoing
{
    public class OutgoingOnboardingResponse
    {
        public string Names { get; set; }
        public string Lastnames { get; set; }
        public DateTime BirthDate { get; set; }
        public string Picture { get; set; }
    }
}