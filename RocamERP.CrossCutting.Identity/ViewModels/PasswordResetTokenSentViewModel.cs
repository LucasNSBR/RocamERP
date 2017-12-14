namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class PasswordResetTokenSentViewModel
    {
        public string Email { get; set; }

        public PasswordResetTokenSentViewModel(string email)
        {
            Email = email;
        }
    }
}
