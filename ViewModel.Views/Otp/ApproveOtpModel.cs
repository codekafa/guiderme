using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Otp
{
    public class ApproveOtpModel : BaseParamModel
    {

        public int OtpType { get; set; }
        public string OtpCode { get; set; }
    }
}
