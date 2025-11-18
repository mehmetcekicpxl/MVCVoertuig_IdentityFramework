using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCVoertuig.Models;
using MVCVoertuig.Models.ViewModels;
using System.Threading.Tasks;

namespace MVCVoertuig.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user =_userManager.Users.Where(x=>x.Email==model.Email).FirstOrDefault();
                var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Voertuig");
                }
            }
            else
            {
                ModelState.AddModelError("", "Probeem met inloggen");
            }
            return View();
        }
        #endregion
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.Email=model.Email;
                user.UserName = model.Email;
                var result = await _userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    return View("Login");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
        #endregion

      
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
