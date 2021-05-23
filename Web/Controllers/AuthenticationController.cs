using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Data.ViewModels.Outgoing;
using Web.Services.Database;
using Web.Util.Attributes;
using Web.Util.Transformers;

namespace Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly PixelCityDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthenticationController(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            PixelCityDbContext dbContext,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        [AnonymousOnly]
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [AnonymousOnly]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginProcessor(IncomingUserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userData.UserName);
                
                if (user != null)
                {
                    var loginResult = await _signInManager
                        .PasswordSignInAsync(user, 
                                            userData.Password, 
                                            true, 
                                            false);

                    if (loginResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            
            TempData["ErrorMessage"] = "Contraseña o Nombre de Usuario incorrecto";
            TempData["ErrorClass"] = "custom-register-alert-warning alert-warning";
            return RedirectToAction("Login");
        }
        
        [AnonymousOnly]
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
        
        [AnonymousOnly]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterProcessor(IncomingRegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                var lowestRankId = _dbContext
                    .Ranks.FirstOrDefault(x => x.Name == "Novato")?.Id ?? 1;
                
                var futureUser = new User
                {
                    UserName = registrationData.UserName.ToLower(), 
                    Email = registrationData.Email,
                    RankId = lowestRankId 
                };
                
                var registrationResult = 
                    await _userManager.CreateAsync(futureUser, 
                                         registrationData.Password);

                if (registrationResult.Succeeded)
                {
                    TempData["ErrorMessage"] = "Usuario registrado exitosamente";
                    TempData["ErrorClass"] = "custom-register-alert-success alert-success";
                    return RedirectToAction("Register");
                }

                TempData["ErrorMessage"] = IdentityErrorCodesTransformer.Init(registrationResult.Errors.FirstOrDefault()?.Code);
                TempData["ErrorClass"] = "custom-register-alert-warning alert-warning";
                return View("Register", _mapper.Map<OutgoingRegistrationData>(registrationData));
            }
            
            TempData["ErrorMessage"] = "Verifique que todos los campos tengan la informacion requerida";
            TempData["ErrorClass"] = "custom-register-alert-warning alert-warning";
            return View("Register", _mapper.Map<OutgoingRegistrationData>(registrationData));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        } 
    }
}