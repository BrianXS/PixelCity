using System;
using System.Collections.Generic;

namespace Web.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public DateTime DateTime { get; set; }

        public User Author { get; set; }
        public int AuthorId { get; set; }

        public Community Community { get; set; }
        public int CommunityId { get; set; }

        public List<Comment> Comments { get; set; }
    }
}