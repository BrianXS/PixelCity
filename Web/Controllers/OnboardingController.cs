using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Services.Repositories.Abstract;
using Web.Util.Transformers;

namespace Web.Controllers
{
    [Authorize]
    [Route("Onboarding")]
    public class OnboardingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ICommunityRepository _communityRepository;

        public OnboardingController(UserManager<User> userManager, IMapper mapper, ICommunityRepository communityRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _communityRepository = communityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            
            if (user.CompletedOnboarding)
                return RedirectToAction("Index", "Home");
            
            return View();
        }
        
        //Todo: Store the user avatar outside the source code
        [HttpPost]
        public async Task<IActionResult> IndexProcessor(IncomingOnboardingRequest data)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);

            _mapper.Map(data, user);
            
            await TransformProfilePicture.StoreProfilePicture(data.ProfilePicture, user.UserName);
            var result = await _userManager.UpdateAsync(user);
            
            return result.Succeeded ? 
                RedirectToAction("SubscribeToPopularCommunities") : RedirectToAction("Index");
        }

        
        [HttpGet("Subscribe")]
        public async Task<IActionResult> SubscribeToPopularCommunities()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            
            if (user.CompletedOnboarding)
                return RedirectToAction("Index", "Home");
            
            user.CompletedOnboarding = true;
            await _userManager.UpdateAsync(user);
            return View(_communityRepository.GetMostActiveCommunities());
        }
    }
}