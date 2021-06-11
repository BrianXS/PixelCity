using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Web.Data.Entities;
using Web.Services.Database;
using Web.Services.Repositories.Abstract;

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
    }
}