using Business.Service.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using ViewModel.Views;
using ViewModel.Views.Mail;

namespace Business.Service
{
    public class GmailMailService : IMailService
    {
        AppSettings _appSettings;
        IExceptionManager _exceptionManager;
        public GmailMailService(IOptions<AppSettings> appSettings, IExceptionManager exceptionManager)
        {
            _appSettings = appSettings.Value;
            _exceptionManager = exceptionManager;
        }
        public CommonResult Send(SendEmailModel emailModel)
        {
            CommonResult result = new CommonResult();
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Timeout = 600000;
                smtp.Host = _appSettings.EmailSettings.SmtpAddress;
                smtp.Port = _appSettings.EmailSettings.SmtpPost;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(_appSettings.EmailSettings.Email, _appSettings.EmailSettings.Password);
                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(_appSettings.EmailSettings.Email);

                if (!string.IsNullOrWhiteSpace(emailModel.ToSingle))
                {
                    mailMsg.To.Add(new MailAddress(emailModel.ToSingle));
                }
                else
                {
                    foreach (var item in emailModel.To)
                    {
                        mailMsg.To.Add(new MailAddress(item));
                    }
                }
               
                mailMsg.Subject = emailModel.Subject;
                mailMsg.Body = emailModel.Body;
                mailMsg.IsBodyHtml = true;
                mailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                smtp.Send(mailMsg);

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                _exceptionManager.HandleException(ex);
            }

            return result;
        }
    }
}
