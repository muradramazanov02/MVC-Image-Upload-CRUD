using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayerAndGenericRepository.Areas.Admin.ViewModels;
using Pronia.Core.Models;

namespace NLayerAndGenericRepository.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new()
        //    {
        //        FullName = "Cavid Suleymanli",
        //        UserName = "Admin",

        //    };
        //    await _userManager.CreateAsync(admin, "Admin123@");
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");
        //    return Ok("admin yarandi!");
        //}
        //public async Task<IActionResult> CreateRoles()
        //{
        //    IdentityRole identityRole = new IdentityRole("SuperAdmin");
        //    IdentityRole identityRole1 = new IdentityRole("Admin");
        //    IdentityRole identityRole2 = new IdentityRole("Member");
        //    await _roleManager.CreateAsync(identityRole);
        //    await _roleManager.CreateAsync(identityRole1);
        //    await _roleManager.CreateAsync(identityRole2);
        //    return Ok("rollar artig yaranib!");
        //}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM adminLoginVM)
        {
            if(!ModelState.IsValid)
                return View();
            AppUser user = await _userManager.FindByNameAsync(adminLoginVM.UserName);
            if(user == null)
            {
                ModelState.AddModelError("","UserName or Password is not valid!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user,adminLoginVM.Password,adminLoginVM.IsPersistent,false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is not valid!");
                return View();  
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
