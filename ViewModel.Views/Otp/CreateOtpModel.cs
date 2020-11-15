using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Otp
{
    public class CreateOtpModel : BaseParamModel
    {

        public int OtpType { get; set; }


        public string EmailOrPhone { get; set; }

    }
}
