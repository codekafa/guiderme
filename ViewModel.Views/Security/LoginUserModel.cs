using System;

namespace ViewModel.Views.Security
{
    [Serializable]
    public class LoginUserModel : BaseParamModel
    {
        public string EmailOrPhone { get; set; }
        public string Password { get; set; }

    }
}
