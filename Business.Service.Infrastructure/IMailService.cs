using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Mail;

namespace Business.Service.Infrastructure
{
    public interface IMailService
    {
        CommonResult Send(SendEmailModel emailModel);

    }
}
