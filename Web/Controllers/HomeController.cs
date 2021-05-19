using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Services.Database;
using Web.Services.Repositories.Abstract;
using Web.Util.Attributes;

namespace Web.Controllers
{
    [Route("/")]
    public class HomeController : Controller 
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPostRepository _postRepository;

        public HomeController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IPostRepository postRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var latestPosts = _postRepository.getLatestPosts();
            return View(latestPosts);
        }
        
        [AnonymousOnly]
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginProcessor(IncomingUserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userData.UserName);
                
                if (user != null)
                {
                    await _signInManager
                        .PasswordSignInAsync(user, 
                                            userData.Password, 
                                            true, 
                                            false);

                    return RedirectToAction("Index");
                }
            }
            
            return View("Login");
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}