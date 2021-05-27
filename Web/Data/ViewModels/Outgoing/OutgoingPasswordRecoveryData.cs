namespace Web.Data.ViewModels.Outgoing
{
    public class OutgoingPasswordRecoveryData
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}