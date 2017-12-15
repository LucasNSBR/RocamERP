using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using RocamERP.CrossCutting.Identity.Extensions;
using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly RocamAppUserManager _userManager;
        private readonly RocamAppSignInManager _signInManager;
        private readonly IAuthenticationManager _authManager;

        public ManageController(RocamAppUserManager userManager, RocamAppSignInManager signInManager, IAuthenticationManager authManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authManager = authManager;
        }

        public async Task<ActionResult> AccountOverview()
        {
            var userId = User.Identity.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);

            AccountOverviewViewModel account = new AccountOverviewViewModel
            {
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                TwoFactorEnabled = user.TwoFactorEnabled,
            };

            return View(account);
        }

        private async Task SendConfirmationEmail(string userEmail)
        {
            await _userManager.SendConfirmationEmailAsync(userEmail);
        }
        
        public async Task<ActionResult> ConfirmEmail()
        {
            var userId = User.Identity.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);

            if (await _userManager.IsEmailConfirmedAsync(userId))
                return RedirectToAction("AccountOverview");
            else
                await SendConfirmationEmail(user.Email);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {
            var userId = User.Identity.GetUserId();

            var result = await _userManager.ConfirmEmailAsync(userId, model.Token);
            if (result.Succeeded)
                return RedirectToAction("AccountOverview");

            return View();
        }
    }
}