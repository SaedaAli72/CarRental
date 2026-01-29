using CarRentalBLL.ViewModels.User;
using CarRentalDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalPL.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register(string role)
        {
            var reg = new RegisterVM
            {
                Role = role
            };
            return View(reg);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM vM)
        {
            if (ModelState.IsValid)
            {

                var userCreation = new AppUser
                {
                    UserName = vM.Email,
                    Email = vM.Email
                };
                var result = await _userManager.CreateAsync(userCreation, vM.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userCreation, vM.Role);
                    await _signInManager.SignInAsync(userCreation, isPersistent: false);
                    return RedirectToAction("Index", "test");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }


            }
            return View(vM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM vM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(vM.Email);
                if (user != null)
                {
                  bool isPasswordValid = await _userManager.CheckPasswordAsync(user, vM.Password);
                    if (isPasswordValid)
                    {
                         await _signInManager.SignInAsync(user, vM.RememberMe);
                        return RedirectToAction("Index", "test");
                    }
                }
              
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(vM);

        }
    }
}