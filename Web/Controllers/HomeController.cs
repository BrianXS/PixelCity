using Microsoft.AspNetCore.Mvc;
using Web.Services.Database;
using Web.Services.Repositories.Abstract;

namespace Web.Controllers
{
    [Route("/")]
    public class HomeController : Controller 
    {
        private readonly IPostRepository _postRepository;

        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var latestPosts = _postRepository.getLatestPosts();
            return View(latestPosts);
        }
        
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}