using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.Models;
using RocamERP.CrossCutting.Identity.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;
using RocamERP.Presentation.Web.Exceptions;
using System;
using Microsoft.Owin.Security;
using RocamERP.CrossCutting.Identity.Extensions;

namespace RocamERP.Presentation.Web.Controllers
{
    [Authorize]
    [ExtendedHandleError()]
    public class AccountController : Controller
    {
        private readonly RocamAppUserManager _userManager;
        private readonly RocamAppSignInManager _signInManager;
        private readonly IAuthenticationManager _authManager;

        public AccountController(RocamAppUserManager userManager, RocamAppSignInManager signInManager, IAuthenticationManager authManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authManager = authManager;
        }

        #region Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = new RocamAppUser { UserName = model.Email, Email = model.Email, Age = model.Age, FirstName = model.FirstName, LastName = model.LastName };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SendConfirmationEmail(model.Email);
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("Um erro ocorreu", "Alguns dados podem estar incorretos.");
            return View();
        }
        
        #endregion


        #region Login 

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPersistent, true);

            switch (result)
            {
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("VerifyTwoFactorToken");
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return RedirectToAction("AccountLocked");
                case SignInStatus.Failure:
                    return RedirectToAction("IncorrectCredentials");
            }

            return View();
        }

        public ActionResult AccountLocked()
        {
            return View();
        }

        public ActionResult IncorrectCredentials()
        {
            ModelState.AddModelError("Credenciais incorretas", "Seu usuário e/ou senha estão incorretos");
            return View("Login");
        }

        #endregion


        #region Two Factor Authentication

        public async Task<ActionResult> VerifyTwoFactorToken()
        {
            var userId = await _signInManager.GetVerifiedUserIdAsync();

            if (await _signInManager.HasBeenVerifiedAsync())
            {
                var token = _userManager.GenerateTwoFactorToken(userId, "TwoFactorEmailAuth");
                await _userManager.SendEmailAsync(userId, "Código de Verificação", token);
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyTwoFactorToken(string token)
        {
            var result = await _signInManager.TwoFactorSignInAsync("TwoFactorEmailAuth", token, false, false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return RedirectToAction("AccountLocked");
                case SignInStatus.Failure:
                    return RedirectToAction("IncorrectCredentials");
            }

            return View();
        }

        #endregion 


        #region Confirm Email
        private async Task SendConfirmationEmail(string userEmail)
        {
            await _userManager.SendConfirmationEmailAsync(userEmail);
        }
        #endregion


        #region Password Reset

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
                await _userManager.SendEmailAsync(user.Id, "Redefinição de senha", $"O código de redefinição de senha é: {code}");
            }

            return RedirectToAction("ResetPasswordTokenSent");
        }

        public ActionResult PasswordResetTokenSent(string email)
        {
            var model = new PasswordResetTokenSentViewModel(email);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            string resetcode = "null";
            var result = await _userManager.ResetPasswordAsync(resetcode, model.ResetCode, model.Password);

            if (result.Succeeded)
                RedirectToAction("Login");

            return View();
        }

        #endregion


        #region Logout

        public ActionResult Logout()
        {
            _authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}