using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public Rank Rank { get; set; }
        public int RankId { get; set; }
        
        public List<Post> Post { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Badge> Badges { get; set; }

        public List<Community> ModeratorCommunity { get; set; }
        public List<Community> MemberCommunity { get; set; }
    }
}