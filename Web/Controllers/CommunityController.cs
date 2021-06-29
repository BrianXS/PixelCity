using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Services.Database;
using Web.Services.Repositories.Abstract;

namespace Web.Controllers
{
    [Route("Comunidades")]
    public class CommunityController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly PixelCityDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICommunityRepository _communityRepository;

        public CommunityController(UserManager<User> userManager, PixelCityDbContext dbContext, 
            IMapper mapper, ICommunityRepository communityRepository)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
            _communityRepository = communityRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet("Crear")]
        public IActionResult Create()
        {
            return View();
        }
        
        
        //Todo: Redirect to community once the community view is done
        [Authorize]
        [HttpPost("Crear")]
        public async Task<IActionResult> CreateProcessor(IncomingCreateCommunityRequest data)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Revise que todos los campos hayan sido llenados.";
                TempData["CssClass"] = "bg-danger";
                return RedirectToAction("Create");
            }

            var currentUser = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            var result = await _communityRepository.SaveCommunity(currentUser, data);

            if (!result)
            {
                TempData["Message"] = "Por favor escoga otra URL.";
                TempData["CssClass"] = "bg-danger";
            }
            else
            {
                TempData["Message"] = "Comunidad guardada exitosamente.";
                TempData["CssClass"] = "custom-settings-alert-success";
            }
            
            return RedirectToAction("Create");
        }

        [HttpGet("{communityUrl}")]
        public IActionResult Community(string communityUrl)
        {
            return View();
        }
        
        [HttpGet("{communityUrl}/new")]
        public IActionResult CreatePost(string communityUrl)
        {
            return View();
        }
        
        //Todo: Redirect To Random
        public IActionResult RandomCommunity()
        {
            return RedirectToAction("Index");
        }
    }
}