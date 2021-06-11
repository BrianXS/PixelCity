using System.Collections.Generic;
using Web.Data.Entities;

namespace Web.Services.Repositories.Abstract
{
    public interface ICommunityRepository
    {
        List<Community> GetMostActiveCommunities();
    }
}