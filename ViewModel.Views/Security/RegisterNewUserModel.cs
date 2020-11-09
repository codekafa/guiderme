using System;

namespace ViewModel.Views.Security
{
    [Serializable]
    public class RegisterNewUserModel
    {
        public int RegisterType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string MobilePhone { get; set; }

    }
}
