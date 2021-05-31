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
using Web.Util.Email;
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
                        if(user.CompletedOnboarding)
                            return RedirectToAction("Index", "Home");

                        return RedirectToAction("Index","Onboarding");
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
                    var token = (await _userManager
                        .GenerateEmailConfirmationTokenAsync(futureUser))
                        .Replace("+", "%2b");

                    await MailSender.SendConfirmationEmail(futureUser.Email, token, futureUser.UserName);

                    TempData["ErrorMessage"] = "Usuario registrado exitosamente, revise su bandeja de entrada y verifique el correo.";
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

        [AnonymousOnly]
        [HttpGet("Confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] IncomingEmailConfirmation data)
        {
            var result = await _userManager.ConfirmEmailAsync(await _userManager.FindByNameAsync(data.Username), data.Token);
            if (result.Succeeded)
            {
                TempData["ErrorMessage"] = "Correo confirmado exitosamente";
                TempData["ErrorClass"] = "custom-register-alert-success alert-success";
            }
            else
            {
                TempData["ErrorMessage"] = "Ha ocurrido un error confirmando el correo";
                TempData["ErrorClass"] = "custom-register-alert-warning alert-warning";
            }
            return RedirectToAction("Login");
        }
        
        [AnonymousOnly]
        [HttpGet("Request-Password-Recovery")]
        public IActionResult RequestPasswordRecovery()
        {
            return View();
        }
        
        [AnonymousOnly]
        [HttpPost("Request-Password-Recovery")]
        public async Task<IActionResult> RequestPasswordRecoveryProcessor(IncomingPasswordRecoveryRequest data)
        {
            if (ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Revisa tu correo, hemos enviado la información para restablecer el acceso";
                TempData["ErrorClass"] = "custom-register-alert-success alert-success";

                var user = await _userManager.FindByNameAsync(data.Username);

                if (user != null)
                {
                    var token = (await _userManager
                        .GeneratePasswordResetTokenAsync(user))
                        .Replace("+", "%2b");

                    await MailSender.SendPasswordRecoveryEmail(user.Email, token, user.UserName);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Introduzca un correo valido";
                TempData["ErrorClass"] = "custom-register-alert-warning alert-warning";
            }
            
            return RedirectToAction("RequestPasswordRecovery");
        }

        [AnonymousOnly]
        [HttpGet("Password-Recovery")]
        public IActionResult PasswordRecovery([FromQuery] IncomingPasswordRecoveryDataFromEmail dataFromEmail)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("RequestPasswordRecovery");
                    
            return View(_mapper.Map<OutgoingPasswordRecoveryData>(dataFromEmail));
        }
        
        [AnonymousOnly]
        [HttpPost("Password-Recovery")]
        public async Task<IActionResult> PasswordRecoveryProcessor(IncomingPasswordRecoveryData data)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(data.Username);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, data.Token, data.Password);
                    if (result.Succeeded)
                    {
                        TempData["ErrorMessage"] = "Contraseña reestablecida correctamente";
                        TempData["ErrorClass"] = "custom-register-alert-success alert-success";
                        return RedirectToAction("Login");
                    }
                }
                
                TempData["ErrorMessage"] = "Ha ocurrido un error inesperado";
                TempData["ErrorClass"] = "custom-register-alert-warning alert-warning";
                return RedirectToAction("Login");
            }
            
            TempData["ErrorMessage"] = "Verifique que ambas contraseñas coincidan";
            TempData["ErrorClass"] = "custom-register-alert-warning alert-warning";
            return RedirectToAction("PasswordRecovery",
                new IncomingPasswordRecoveryDataFromEmail {Username = data.Username, Token = data.Token});
        }
        
        [AnonymousOnly]
        [HttpGet("Request-Confirmation-Email")]
        public IActionResult RequestConfirmationEmail()
        {
            return View();
        }
        
        [AnonymousOnly]
        [HttpPost("Request-Confirmation-Email")]
        public async Task<IActionResult> RequestConfirmationEmailProcessor(IncomingEmailConfirmationResendRequest data)
        {
            var user = await _userManager.FindByNameAsync(data.Username);
            if (user != null)
            {
                var token = (await _userManager
                    .GenerateEmailConfirmationTokenAsync(user))
                    .Replace("+", "%2b");

                await MailSender.SendConfirmationEmail(user.Email, token, user.UserName);
            }
            
            TempData["ErrorMessage"] = "Revise su bandeja de entrada y verifique el correo.";
            TempData["ErrorClass"] = "custom-register-alert-success alert-success";
            return RedirectToAction("Login");
        }
        
        [AnonymousOnly]
        [HttpGet("Request-Username-Email")]
        public IActionResult RequestUsername()
        {
            return View();
        }
        
        [AnonymousOnly]
        [HttpPost("Request-Username-Email")]
        public async Task<IActionResult> RequestUsernameProcessor(IncomingUsernameRecoveryRequest data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);
            if (user != null)
            {
                await MailSender.SendUsernameRecoveryEmail(user.Email, user.UserName);
            }
            
            TempData["ErrorMessage"] = "Revise su bandeja de entrada, hemos enviado su nombre de usuario.";
            TempData["ErrorClass"] = "custom-register-alert-success alert-success";
            return RedirectToAction("Login");
        }
    }
}