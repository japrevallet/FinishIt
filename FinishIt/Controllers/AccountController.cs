using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinishIt.Services;
using FinishIt.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinishIt.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(user, model.Password);
                var resultRole = await userManager.AddToRoleAsync(user, "User");  //new users automatically User role

                string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = confirmationToken }, protocol: HttpContext.Request.Scheme);
                EmailService.Send(user.Email, "Confirm Your Email", "Click Here To Confirm your Email Address "+ confirmationLink);
                // System.IO.File.WriteAllText();
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.Msg = "Email confirmation Succeeded!";
            }
            else
            {
                ViewBag.Msg = "Email confirmation Failed...";
            }
            
            return View();
        }


        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> LogIn(LogInViewModel model)
        {
            var Result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,true); //this could take IdentityUser object but instead imma use my LogInViewModel.userName 
            if (Result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            { 
            var user = await userManager.FindByEmailAsync(model.UserEmail);
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            string resetLink = Url.Action("ResetPassword", "Account", new { userid = user.Id }, protocol: HttpContext.Request.Scheme);  // You need to sent resetLink to userEmail
            ViewBag.Msg = "Reset Password Link Has Been Sent to your Email";
            }
            return View();
        }



        //[HttpPost]
        //public IActionResult ResetPassword(string userId, string token)
        //{
        //    var obj = new ResetPasswordViewModel() { UserId = userId, Token = token };

        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                ViewBag.Msg = "Password Reset Succeeded!";
            }
            else
            {
                ViewBag.Msg = "Password Reset Failed...";
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account");
        }
    }
}