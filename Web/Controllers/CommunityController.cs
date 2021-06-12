using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;

namespace Web.Controllers
{
    [Route("Comunidades")]
    public class CommunityController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public CommunityController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}