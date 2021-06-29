using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Services.Database;
using Web.Services.Repositories.Abstract;
using Web.Util.Transformers;

namespace Web.Services.Repositories.Implementation
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly PixelCityDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommunityRepository(PixelCityDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public List<Community> GetMostActiveCommunities()
        {
            return _dbContext.Communities.OrderByDescending(x => x.Posts.Count).Take(6).ToList();
        }

        public async Task<bool> SaveCommunity(User currentUser, IncomingCreateCommunityRequest data)
        {
            var community = _mapper.Map<Community>(data);
            community.Moderators = new List<User> {currentUser};
            community.Members = new List<User> {currentUser};

            try
            {
                await _dbContext.Communities.AddAsync(community);
                await _dbContext.SaveChangesAsync();
                
                await TransformProfilePicture.StoreACommunityPicture(data.Picture, community.Id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}