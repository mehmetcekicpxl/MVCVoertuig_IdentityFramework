using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCVoertuig.Models.ViewModels;
using System.Threading.Tasks;

namespace MVCVoertuig.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
        public IActionResult Login(LoginViewModel model)
        {
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
    }
}
