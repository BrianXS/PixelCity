using System.Collections.Generic;

namespace Web.Data.Entities
{
    public class Badge
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconPath { get; set; }

        public List<User> Users { get; set; }
    }
}