using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;
using Web.Services.Database;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("SubscribeToCommunity")]
    public class CommunitySubscriptionController : ControllerBase
    {
        private readonly PixelCityDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public CommunitySubscriptionController(PixelCityDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet("Join/{id}")]
        public async Task<JsonResult> Join(int id)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            var community = _dbContext.Communities
                .Include(x => x.Members)
                .FirstOrDefault(x => x.Id == id);

            if (community == null)
                return new JsonResult("Community not found");

            if (community.Members.Contains(user))
                return new JsonResult("User already belongs to this community");
            
            community.Members.Add(user);
            _dbContext.Communities.Update(community);
            await _dbContext.SaveChangesAsync();
            
            return new JsonResult($"success");
        }
        
        [HttpGet("Leave/{id}")]
        public async Task<JsonResult> Leave(int id)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            var community = _dbContext.Communities
                .Include(x => x.Members)
                .FirstOrDefault(x => x.Id == id);

            if (community == null)
                return new JsonResult("Community not found");

            if (!community.Members.Contains(user))
                return new JsonResult("User doesn't belong to this community");
            
            community.Members.Remove(user);
            _dbContext.Communities.Update(community);
            await _dbContext.SaveChangesAsync();
            
            return new JsonResult($"success");
        }
    }
}