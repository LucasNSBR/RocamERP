using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RocamERP.CrossCutting.Identity.Extensions;
using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.Models;
using RocamERP.CrossCutting.Identity.ViewModels;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.Filters;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Controllers
{
    [Authorize]
 //   [ExtendedHandleError()]
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
        [AuthenticatedRequestFilter]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [AuthenticatedRequestFilter]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalRegister(ExternalRegisterViewModel model)
        {
            var userInfo = await _authManager.GetExternalLoginInfoAsync();
            if (userInfo == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("Erro de registro", "Ocorreu um erro ao registrar o novo usuário.");
                return RedirectToAction("Index", "Home");
            }

            var user = Mapper.Map<ExternalRegisterViewModel, RocamAppUser>(model);
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                var claim = await _userManager.AddLoginAsync(user.Id, userInfo.Login);
                //await SendConfirmationEmail(user.Email);
                return RedirectToAction("Overview", "Manage");
            }

            ModelState.AddModelError("Erro de registro", "Ocorreu um erro ao registrar o novo usuário.");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [AuthenticatedRequestFilter]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = Mapper.Map<RegisterViewModel, RocamAppUser>(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SendConfirmationEmail(model.Email);
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("Erro de formulário", "Alguns dados podem estar incorretos.");
            return View();
        }

        [AllowAnonymous]
        [AuthenticatedRequestFilter]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [AuthenticatedRequestFilter]
        public ActionResult ExternalLogin(string provider)
        {
            string returnUrl = Url.Action("ExternalLoginCallback");
            return new ChallengeResult(_authManager, provider, returnUrl);
        }

        [AllowAnonymous]
        [AuthenticatedRequestFilter]
        public async Task<ActionResult> ExternalLoginCallback()
        {
            var user = await _authManager.GetExternalLoginInfoAsync();

            if (user != null)
            {
                var result = await _signInManager.ExternalSignInAsync(user, false);

                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToAction("Overview", "Manage");
                    case SignInStatus.RequiresVerification:
                        return Redirect("VerifyTwoFactorToken");
                    case SignInStatus.LockedOut:
                        return RedirectToAction("AccountLocked");
                    case SignInStatus.Failure:
                        {
                            if (await _userManager.FindByEmailAsync(user.Email) == null){
                                return View("ExternalRegister", new ExternalRegisterViewModel(user.Login.LoginProvider, user.Email));
                            }
                        }

                        return RedirectToAction("ExternalLoginFailure");
                }
            }

            ModelState.AddModelError("Erro de registro", "Ocorreu um erro ao registrar o novo usuário.");
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [AuthenticatedRequestFilter]
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
                    ModelState.AddModelError("Erro de credenciais", "Seu usuário e/ou senha estão incorretos.");
                    break;
            }

            return View();
        }

        public ActionResult AccountLocked()
        {
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
                    ModelState.AddModelError("Erro de Token", "O código de verificação está incorreto.");
                    break;
            }

            return View();
        }

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

        public ActionResult Logout()
        {
            Session.Clear();
            Request.Cookies.Clear();
            _authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            private readonly IAuthenticationManager _manager;
            private readonly string _returnUrl;
            private readonly string _provider;

            public ChallengeResult(IAuthenticationManager manager, string provider, string returnUrl)
            {
                _manager = manager;
                _provider = provider;
                _returnUrl = returnUrl;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    RedirectUri = _returnUrl
                };

                _manager.Challenge(properties, _provider);
            }
        }
    }
}