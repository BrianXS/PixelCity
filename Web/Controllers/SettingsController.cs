using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Data.ViewModels.Outgoing;
using Web.Util.Transformers;

namespace Web.Controllers
{
    [Authorize]
    [Route("Settings")]
    public class SettingsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public SettingsController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> UserSettings()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            return View(_mapper.Map<OutgoingUserUpdateResponse>(user));
        }
        
        [HttpPost]
        public async Task<IActionResult> UserSettingsProcessor(IncomingUserUpdateRequest data)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Ha ocurrido un error actualizando tus datos";
                TempData["CssClass"] = "bg-danger";
                
                return RedirectToAction("UserSettings");
            }
            
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            
            _mapper.Map(data, user);
            user.BirthDate = data.BirthDate;
            
            if(data.Picture != null)
               await TransformProfilePicture.StoreProfilePicture(data.Picture, user.UserName);
    
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Message"] = "Tus datos fueron actualizados exitosamente";
                TempData["CssClass"] = "custom-settings-alert-success";
            }
            else
            {
                TempData["Message"] = "Ha ocurrido un error actualizando tus datos";
                TempData["CssClass"] = "bg-danger";
            }
            
            return RedirectToAction("UserSettings");
        }
        
        [HttpGet("Change-Password")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        
        [HttpPost("Change-Password")]
        public async Task<IActionResult> ChangePasswordProcessor(IncomingChangePasswordRequest data)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Verifique que todos los datos sean correctos";
                TempData["CssClass"] = "bg-danger";
                return RedirectToAction("ChangePassword");
            }
            
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            var result = await _userManager.ChangePasswordAsync(user, data.CurrentPassword, data.NewPassword);

            if (result.Succeeded)
            {
                TempData["Message"] = "La contraseña fue cambiada exitosamente";
                TempData["CssClass"] = "custom-settings-alert-success";
            }
            else
            {
                TempData["Message"] = "Ha ocurrido un error cambiando la contraseña";
                TempData["CssClass"] = "bg-danger";
            }

            return RedirectToAction("ChangePassword");
        }

        [HttpPost("delete-account")]
        public async Task<IActionResult> DeleteAccount(string deleteAccountPassword)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
            var passwordVerification = await _userManager.CheckPasswordAsync(user, deleteAccountPassword);

            if (passwordVerification)
            {
                var deletionResult = await _userManager.DeleteAsync(user);

                if (deletionResult.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["Message"] = "Contraseña erronea, verifiquela e intente nuevamente";
            TempData["CssClass"] = "bg-danger";
            
            var referer = Request.Headers["Referer"].ToString();

            return !string.IsNullOrWhiteSpace(referer) ? 
                Redirect(referer) : RedirectToAction("UserSettings");
        }
    }
}