using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.Models;
using RocamERP.CrossCutting.Identity.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;
using RocamERP.Presentation.Web.Exceptions;
using System.Web;

namespace RocamERP.Presentation.Web.Controllers
{
    [Authorize]
    [ExtendedHandleError()]
    public class AccountController : Controller
    {
        private readonly RocamAppUserManager _userManager;
        private readonly RocamAppSignInManager _signInManager;

        public AccountController(RocamAppUserManager userManager, RocamAppSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Index()
        {
            return View();
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
            if(!ModelState.IsValid)
                return View();

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberPassword, true);
            switch (result)
            {
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("ConfirmLogin");
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Cheques", new { area = "Plataforma" });

                case SignInStatus.Failure:
                case SignInStatus.LockedOut:
                default:
                    return RedirectToAction("Login");
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);

                await _userManager.SendEmailAsync(user.Id, "Redefinição de senha", $"O código de redefinição de senha é: {code}");
            }

            return RedirectToAction("ForgotPasswordEmailSent");
        }

        public ActionResult ForgotPasswordEmailSent()
        {
            return View();
        }
    }
}