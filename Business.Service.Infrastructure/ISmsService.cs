using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Sms;

namespace Business.Service.Infrastructure
{
    public interface ISmsService
    {

        CommonResult SendSms(CreateSmsModel request);

    }
}
