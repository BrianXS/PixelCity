using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Data.ViewModels.Outgoing;
using Web.Services.Database;
using Web.Services.Repositories.Abstract;
using Web.Util.Attributes;
using Web.Util.Transformers;

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