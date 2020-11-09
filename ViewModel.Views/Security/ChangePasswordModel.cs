using System;

namespace ViewModel.Views.Security
{
    [Serializable]
    public class ChangePasswordModel
    {
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string Email { get; set; }
    }
}
