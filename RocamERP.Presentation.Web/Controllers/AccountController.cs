using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.Models;
using RocamERP.CrossCutting.Identity.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;
using RocamERP.Presentation.Web.Exceptions;
using Microsoft.Owin.Security;

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
            if (!ModelState.IsValid)
                return View();

            var user = new RocamAppUser { UserName = model.Email, Email = model.Email, Age = model.Age, FirstName = model.FirstName, LastName = model.LastName };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return RedirectToAction("Login");
            else
            {
                ModelState.AddModelError("Um erro foi encontrado", "Ocorreu um erro ao fazer essa operação");
                return View();
            }
        }

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
            if (!ModelState.IsValid)
                return View();

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPersistent, false);
            switch (result)
            {
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("VerifyTwoFactorToken");
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return RedirectToAction("AccountLocked");
                case SignInStatus.Failure:
                default:
                    return RedirectToAction("Login");
            }
        }

        public async Task<ActionResult> VerifyEmail()
        {
            var userId = User.Identity.GetUserId();

            if (await _userManager.IsEmailConfirmedAsync(userId))
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyEmail(ConfirmEmailViewModel model)
        {
            var userId = User.Identity.GetUserId();

            var result = await _userManager.ConfirmEmailAsync(userId, model.Token);
            if (result.Succeeded)
                return RedirectToAction("Index");

            return View();
        }

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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> VerifyTwoFactorToken(string token, string provider)
        //{
        //    var result = await _signInManager.TwoFactorSignInAsync(provider, token, false, false);
        //    if (result == SignInStatus.Success)

        //}

        public ActionResult AccountLocked()
        {
            return View();
        }

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

        public ActionResult Logout()
        {
            _authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}