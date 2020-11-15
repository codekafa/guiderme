using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Otp;

namespace Business.Service.Infrastructure
{
    public interface IOtpService
    {
        CommonResult CreateNewOtp(CreateOtpModel request);

        CommonResult ApproveOtp(CheckOtpCode request);
    }
}
