using Microsoft.AspNet.Identity;
using RocamERP.CrossCutting.Identity.Models;
using RocamERP.CrossCutting.Identity.Services;

namespace RocamERP.CrossCutting.Identity.Managers
{
    public class RocamAppUserManager : UserManager<RocamAppUser>
    {
        public RocamAppUserManager(IUserStore<RocamAppUser> userStore) : base(userStore)
        {
            ConfigurePasswordValidator();
            ConfigureUserNameValidator();
            ConfigureLockoutOptions();
            ConfigureMessagingServices();
            ConfigureTwoFactorAuthentication();
            ConfigureUserTokens();
        }

        #region Configuration
        private void ConfigureUserNameValidator()
        {
            UserValidator = new UserValidator<RocamAppUser>(this)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = true
            };
        }

        private void ConfigurePasswordValidator()
        {
            PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequiredLength = 6,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };
        }

        private void ConfigureLockoutOptions()
        {
            MaxFailedAccessAttemptsBeforeLockout = 5;
            UserLockoutEnabledByDefault = true;
        }

        private void ConfigureMessagingServices()
        {
            SmsService = IdentitySmsService.Create();
            EmailService = IdentityEmailService.Create();
        }

        private void ConfigureUserTokens()
        {
            UserTokenProvider = new EmailTokenProvider<RocamAppUser, string>();
        }

        private void ConfigureTwoFactorAuthentication()
        {
            TwoFactorProviders.Add("TwoFactorEmailAuth", new EmailTokenProvider<RocamAppUser, string>());
            //TwoFactorProviders.Add("TwoFactorSmsAuth", new PhoneNumberTokenProvider<RocamAppUser, string>());
        }
        #endregion
    }
}
