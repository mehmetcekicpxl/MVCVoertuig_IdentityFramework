using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Models.ViewModels;

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
        public IActionResult Register(LoginViewModel model)
        {
            return View();
        }
        #endregion
    }
}
