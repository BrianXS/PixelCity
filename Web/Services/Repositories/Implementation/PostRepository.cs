using System.Collections.Generic;
using System.Linq;
using Web.Data.Entities;
using Web.Services.Database;
using Web.Services.Repositories.Abstract;

namespace Web.Services.Repositories.Implementation
{
    public class PostRepository : IPostRepository
    {
        private readonly PixelCityDbContext _dbContext;

        public PostRepository(PixelCityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<Post> getLatestPosts()
        {
            return _dbContext.Posts.OrderBy(x => x.DateTime).ToList();
        }
    }
}