using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Otp;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class OtpService : IOtpService
    {
        IMailService _mailService;
        ISmsService _smsService;
        IQuerableRepository _queryRepo;
        ILexiconService _lexService;
        IDocumentService _documentService;
        IUnitOfWork _uow;
        IRequestService _requestService;
        public OtpService(IMailService mailService, ISmsService smsService, IQuerableRepository queryRepo, ILexiconService lexService, IDocumentService documentService , IUnitOfWork unitOfWork, IRequestService requestService)
        {
            _mailService = mailService;
            _smsService = smsService;
            _queryRepo = queryRepo;
            _lexService = lexService;
            _documentService = documentService;
            _uow = unitOfWork;
            _requestService = requestService;
        }
        public CommonResult CreateNewOtp(CreateOtpModel request)
        {
            CommonResult result = new CommonResult();
            CommonResult otpResult = new CommonResult();

            string otp = GetOrpCode();
            var newOtp = _uow.OtpTransactionRepository.Add(new OtpTransaction { ExpireDate = DateTime.Now.AddDays(1), IsActive = true, IsUsed = false, OTPCode = otp, OTPType = request.OtpType, UserID = request.CurrentUserId });
            _uow.SaveChanges();
            request.OtpCode = otp;

            if (request.OtpType == (int)OtpTypes.Email)
                otpResult = CreateEmailOtp(request);
            else if (request.OtpType == (int)OtpTypes.Sms)
                otpResult = CreateSmsOtp(request);
            else if (request.OtpType == (int)OtpTypes.ChangePassword)
                otpResult = CreateChangeEmailOtp(request);

            if (otpResult.IsSuccess)
            {
                result.IsSuccess = true;
                result.Data = otp;
            }

            return result;

        }
        string GetOrpCode()
        {
            string otp = "";

            var lastOtp = _queryRepo.GetSingle<OtpTransaction>("SELECT * FROM OtpTransactions   order by ID desc LIMIT 1", null);

            if (lastOtp == null)
            {
                otp = "145675";
                return otp;
            }
            else
            {
                long otpvalue = Convert.ToInt64(lastOtp.OTPCode);
                otpvalue = otpvalue + 1;
                return otpvalue.ToString();
            }
        }
        CommonResult CreateChangeEmailOtp(CreateOtpModel request)
        {
            string htmlText = _documentService.GetStringDocument(@"Views\Template\ChangePasswordMail.cshtml");
            htmlText = htmlText.Replace("$$user_dear_text$$", _lexService.GetTextValue("change_password_dear_text", 12));
            htmlText = htmlText.Replace("$$user_dear$$", request.EmailOrPhone);
            htmlText = htmlText.Replace("$$user_description$$", _lexService.GetTextValue("_change_password_description", 12));
            htmlText = htmlText.Replace("$$change_link_text$$", _lexService.GetTextValue("_change_password_link_text", 12));
            htmlText = htmlText.Replace("$$change_link$$", _lexService.GetTextValue("_domain_name", 99) + "change-password/" + request.OtpCode);
            htmlText = htmlText.Replace("$$follow_us$$", _lexService.GetTextValue("_follow_us", 99));
            htmlText = htmlText.Replace("$$instagram$$", _lexService.GetTextValue("_instagram", 99));
            htmlText = htmlText.Replace("$$contact_phone$$", _lexService.GetTextValue("_contact_phone", 99));
            htmlText = htmlText.Replace("$$contact_email$$", _lexService.GetTextValue("_contact_email", 99));
            htmlText = htmlText.Replace("$$service_here$$", _lexService.GetTextValue("_service_here_brand_text", 99));
            htmlText = htmlText.Replace("$$domain_name$$", _lexService.GetTextValue("_domain_name", 99));

            var result = _mailService.Send(new ViewModel.Views.Mail.SendEmailModel { ToSingle = request.EmailOrPhone, Body = htmlText, IsHtml = true, Subject = _lexService.GetTextValue("_change_password_mail_subject", 12) });

            return result;
        }
        CommonResult CreateEmailOtp(CreateOtpModel request)
        {
            string htmlText = _documentService.GetStringDocument(@"Views\Template\EmailOtp.cshtml");
            htmlText = htmlText.Replace("$$register_dear_text$$", _lexService.GetTextValue("_otp_register_dear_text", 12));         
            htmlText = htmlText.Replace("$$otp_ode$$", request.OtpCode);
            htmlText = htmlText.Replace("$$register_dear$$", request.EmailOrPhone);
            htmlText = htmlText.Replace("$$register_description$$", _lexService.GetTextValue("_otp_email_description", 12));
            htmlText = htmlText.Replace("$$follow_us$$", _lexService.GetTextValue("_follow_us", 99));
            htmlText = htmlText.Replace("$$instagram$$", _lexService.GetTextValue("_instagram", 99));
            htmlText = htmlText.Replace("$$contact_phone$$", _lexService.GetTextValue("_contact_phone", 99));
            htmlText = htmlText.Replace("$$contact_email$$", _lexService.GetTextValue("_contact_email", 99));
            htmlText = htmlText.Replace("$$service_here$$", _lexService.GetTextValue("_service_here_brand_text", 99));
            htmlText = htmlText.Replace("$$domain_name$$", _lexService.GetTextValue("_domain_name", 99));

            var result = _mailService.Send(new ViewModel.Views.Mail.SendEmailModel { ToSingle = request.EmailOrPhone, Body = htmlText, IsHtml = true, Subject = _lexService.GetTextValue("_otp_email_subject", 12) });

            return result;
        }
        CommonResult CreateSmsOtp(CreateOtpModel request)
        {
            CommonResult result = new CommonResult();
            //result = _smsService.SendSms(new ViewModel.Views.Sms.CreateSmsModel { });
            result.IsSuccess = true;
            return result;
        }
        public CommonResult ApproveOtp(CheckOtpCode otpModel)
        {
            CommonResult result = new CommonResult();
            var otp = _uow.OtpTransactionRepository.Get(x => x.OTPCode == otpModel.OtpCode);

            if (otp == null)
            {
                result.IsSuccess = false;
                result.Data = _lexService.GetAlertSring("_otp_not_found!", otpModel.CultureCode);
                return result;
            }

            if (otpModel.CheckUsed && otp.IsUsed)
            {
                result.IsSuccess = false;
                result.Data = _lexService.GetAlertSring("_otp_already_used!", otpModel.CultureCode);
                return result;
            }

            if (DateTime.Now > otp.ExpireDate)
            {
                result.IsSuccess = false;
                result.Data = _lexService.GetAlertSring("_otp_has_been_expired!", otpModel.CultureCode);
                return result;
            }

            otp.IsUsed = true;
            _uow.OtpTransactionRepository.Update(otp);
            _uow.SaveChanges();
            _requestService.PublishWaitingRequests(otp.UserID);

            result.IsSuccess = true;
            result.Data = otp;
            result.Message = _lexService.GetAlertSring("_otp_successfully_approved!", otpModel.CultureCode);
            return result;
        }
        public bool CheckOtpCode(string otp_code)
        {

            var exist = _uow.OtpTransactionRepository.Get(x => x.IsActive == true && x.OTPCode == otp_code && x.IsUsed == false && x.OTPType == (int)OtpTypes.ChangePassword);

            if (exist == null)
                return false;
            else
            {
                exist.IsUsed = true;
                _uow.OtpTransactionRepository.Update(exist);
                _uow.SaveChanges();
                return true;
            }
        }
        public CommonResult GetOtpResult(string otp_code, int type)
        {
            CommonResult result = new CommonResult();
            var exist = _uow.OtpTransactionRepository.Get(x => x.OTPCode == otp_code && x.OTPType == type);

            if (exist != null)
                result.IsSuccess = true;

            result.Data = exist;
            return result;

        }
    }
}
