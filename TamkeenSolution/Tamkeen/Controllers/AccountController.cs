using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tamkeen.Domain.Entities;
using Tamkeen.Models.ModelsView;

namespace Tamkeen.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;


        public AccountController(
            UserManager<IdentityUser<int>> userManager,
            SignInManager<IdentityUser<int>> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ========================
        // Register GET
        // ========================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ========================
        // Register POST
        // ========================
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser<int>
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    
                };

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }// ... rest of your logic
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 1. ابحث عن المستخدم بواسطة الإيميل أولاً
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // 2. استخدم الـ UserName الحقيقي المخزن في قاعدة البيانات لتسجيل الدخول
                    var result = await _signInManager.PasswordSignInAsync(
                        user.UserName,
                        model.Password,
                        model.RememberMe,
                        lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                }

                // إذا لم ينجح، أظهر خطأ
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
