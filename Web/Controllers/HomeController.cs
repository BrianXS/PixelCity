using Microsoft.AspNetCore.Mvc;
using Web.Services.Repositories.Abstract;

namespace Web.Controllers
{
    //Todo: Implement the remind me my username
    //Todo: Implement the password recover method
    //Todo: Implement the verify mail method
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
    }
}