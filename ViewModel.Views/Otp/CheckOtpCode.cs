using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Otp
{
    public class CheckOtpCode : BaseParamModel
    {

        public string OtpCode { get; set; }

        public bool CheckUsed { get; set; }

    }
}
