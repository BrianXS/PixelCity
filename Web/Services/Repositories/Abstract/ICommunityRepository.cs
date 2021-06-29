using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;

namespace Web.Services.Repositories.Abstract
{
    public interface ICommunityRepository
    {
        List<Community> GetMostActiveCommunities();
        Task<bool> SaveCommunity(User currentUser, IncomingCreateCommunityRequest data);

    }
}