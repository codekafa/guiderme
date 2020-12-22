using Business.Service.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using ViewModel.Views;
using ViewModel.Views.Mail;

namespace Business.Service
{
    public class GodadyMailService : IMailService
    {
        AppSettings _appSettings;
        ILexiconService _lexiconService;
        public GodadyMailService(IOptions<AppSettings> appSettings, ILexiconService lexiconService)
        {
            _appSettings = appSettings.Value;
            _lexiconService = lexiconService;
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
                smtp.EnableSsl = false;
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
                result.Message = _lexiconService.GetTextValue("_email_sended_successfuly", 99);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
