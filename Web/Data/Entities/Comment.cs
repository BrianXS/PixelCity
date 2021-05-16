using System;

namespace Web.Data.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        
        public string Content { get; set; }
        public DateTime DateTime { get; set; }

        public int Score { get; set; }
        
        public User Commenter { get; set; }
        public int CommenterId { get; set; }
        
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}