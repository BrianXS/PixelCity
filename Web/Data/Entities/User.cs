using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Web.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfilePicture { get; set; }
        
        public bool CompletedOnboarding { get; set; }
        public Rank Rank { get; set; }
        public int RankId { get; set; }
        
        public List<Post> Post { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Badge> Badges { get; set; }

        public List<Community> ModeratorCommunity { get; set; }
        public List<Community> MemberCommunity { get; set; }
    }
}