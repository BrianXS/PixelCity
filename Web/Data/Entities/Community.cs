using System.Collections.Generic;

namespace Web.Data.Entities
{
    public class Community
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public List<User> Moderators { get; set; }
        public List<User> Members { get; set; }
        public List<Post> Posts { get; set; }
    }
}