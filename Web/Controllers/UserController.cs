using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.Services.Database;

namespace Web.Controllers
{
    [Authorize]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly PixelCityDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserController(PixelCityDbContext dbContext,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        //Todo: Filter activity based on the top secondary nav bar
        [HttpGet("{username}")]
        public async Task<IActionResult> UserProfile(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return View();
        }
    }
}