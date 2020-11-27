using System;

namespace ViewModel.Views.Security
{
    [Serializable]
    public class ChangePasswordModel : BaseParamModel
    {
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
