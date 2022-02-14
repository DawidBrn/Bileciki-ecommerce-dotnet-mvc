using Bileciki_ecommerce.Data;
using Bileciki_ecommerce.Models.Indentity;
using Bileciki_ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bileciki_ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            var result = new LoginVM();

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
                return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);
            if (user != null) {
            var passwordCheck = await _userManager.CheckPasswordAsync(user,loginVM.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password,false,false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                else
                {
                    TempData["Error"] = "email or password is wrong";
                    return View(loginVM);
                }
            }
            TempData["Error"] = "email or password is wrong";
            return View(loginVM);
        }
    }
}
