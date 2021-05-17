using System.Collections.Generic;
using Web.Data.Entities;

namespace Web.Services.Repositories.Abstract
{
    public interface IPostRepository
    {
        List<Post> getLatestPosts();
    }
}