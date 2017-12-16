using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using RocamERP.CrossCutting.Identity.Extensions;
using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.Models;
using RocamERP.CrossCutting.Identity.ViewModels;
using System.Security.Claims;
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

        public async Task<ActionResult> Overview()
        {
            var userId = User.Identity.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            var account = Mapper.Map<RocamAppUser, OverviewViewModel>(user);

            return View(account);
        }

        public async Task<ActionResult> SendConfirmationEmail()
        {
            var userId = User.Identity.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);

            if (await _userManager.IsEmailConfirmedAsync(userId))
            {
                ModelState.AddModelError("Erro de confirmação", "Seu e-mail já está confirmado.");
                return RedirectToAction("Overview");
            }

            await _userManager.SendConfirmationEmailAsync(user.Email);
            return RedirectToAction("Overview");
        }

        public async Task<ActionResult> ConfirmEmail(string token)
        {   
            var userId = User.Identity.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ConfirmEmailAsync(userId, token);
            if (result.Succeeded)
            {
                return RedirectToAction("Overview");
            }

            ModelState.AddModelError("Erro de confirmação", "Não foi possível confirmar seu e-mail.");
            return RedirectToAction("Overview");
        }
    }
}