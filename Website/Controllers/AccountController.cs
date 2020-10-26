using Website.CustomIdentity;
using Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register (RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = new CustomIdentityUser
            {
                UserName = registerViewModel.UserName,
                Email=registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callBackUrl = Url.Action("ConfirmEmail", "Account",
                    new {userId=user.Id, code=confirmationCode});

                //send email


                return RedirectToAction("Index", "Admin");
            }

            return View(registerViewModel);

            //if (ModelState.IsValid)
            //{
            //    CustomIdentityUser user = new CustomIdentityUser
            //    {
            //        UserName = registerViewModel.UserName,
            //        Email = registerViewModel.Email
            //    };

            //    IdentityResult result =
            //        _userManager.CreateAsync(user, registerViewModel.Password).Result;

            //    if (result.Succeeded)
            //    {
            //        if (!_roleManager.RoleExistsAsync("Admin").Result)
            //        {
            //            CustomIdentityRole role = new CustomIdentityRole
            //            {
            //                Name = "Admin"
            //            };

            //            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

            //            if (!roleResult.Succeeded)
            //            {
            //                ModelState.AddModelError("", "Rol eklenemiyor.");
            //                return View(registerViewModel);
            //            }
            //        }

            //        _userManager.AddToRoleAsync(user, "Admin").Wait();
            //        return RedirectToAction("Login", "Account");
            //    }
            //}

            //return View(registerViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password, false,false).Result;
                //loginViewModel.Password, loginViewModel.RememberMe, false).Result;


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }

                ModelState.AddModelError("", "Geçersiz Giriş!");
            }

            return View(loginViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDeniend()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId==null||code==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user==null)
            {
                throw new ApplicationException("Kullanıcı Bulunamadı");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View("ConfirmEmail"); //Bilgilendirmek için view açabiliriz.
            }
            return RedirectToAction("Index", "Admin");
        }

    }
}
