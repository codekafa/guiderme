using System;
using ViewModel.Views.Request;

namespace ViewModel.Views.Security
{
    [Serializable]
    public class RegisterNewUserModel : BaseParamModel
    {
        public int RegisterType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public string PhotoUrl { get; set; }
        public string Password { get; set; }

        public string PasswordAgain { get; set; }

        public NewRequestModel RequestModel { get; set; }
    }
}
