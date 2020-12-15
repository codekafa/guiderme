using System;
using ViewModel.Views.Request;

namespace ViewModel.Views.Security
{
    [Serializable]
    public class LoginUserModel : BaseParamModel
    {
        public string EmailOrPhone { get; set; }
        public string Password { get; set; }
        public string GoogleToken { get; set; }

        public string FacebookToken { get; set; }
        public NewRequestModel RequestModel { get; set; }
        public string ProfilePhoto { get; set; }
        public string Name { get; set; }
    }
}
