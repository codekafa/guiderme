﻿using Business.Service.Infrastructure;
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
        IOtpTransactionRepository _otpRepo;
        IMailService _mailService;
        ISmsService _smsService;
        IQuerableRepository _queryRepo;
        ILexiconService _lexService;
        IDocumentService _documentService;
        public OtpService(IOtpTransactionRepository otpRepo, IMailService mailService, ISmsService smsService, IQuerableRepository queryRepo, ILexiconService lexService, IDocumentService documentService)
        {
            _otpRepo = otpRepo;
            _mailService = mailService;
            _smsService = smsService;
            _queryRepo = queryRepo;
            _lexService = lexService;
            _documentService = documentService;
        }

        public CommonResult CreateNewOtp(CreateOtpModel request)
        {
            CommonResult result = new CommonResult();
            CommonResult otpResult = new CommonResult();

            string otp = GetOrpCode();
            var newOtp = _otpRepo.Add(new OtpTransaction { ExpireDate = DateTime.Now.AddDays(1), IsActive = true, IsUsed = false, OTPCode = otp, OTPType = request.OtpType, UserID = request.CurrentUserId });

            request.OtpCode = otp;

            if (request.OtpType == (int)OtpTypes.Email)
                otpResult = CreateEmailOtp(request);
            else
                otpResult = CreateSmsOtp(request);

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

            var lastOtp = _queryRepo.GetSingle<OtpTransaction>("SELECT * FROM OtpTransactions  order by ID desc LIMIT 1", null);


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
        CommonResult CreateEmailOtp(CreateOtpModel request)
        {
            string htmlText = _documentService.GetStringDocument(@"Views\Template\EmailOtp.cshtml");
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
            var otp = _otpRepo.Get(x => x.OTPCode == otpModel.OtpCode);

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

            if (DateTime.Now > otp.ExpireDate )
            {
                result.IsSuccess = false;
                result.Data = _lexService.GetAlertSring("_otp_has_been_expired!", otpModel.CultureCode);
                return result;
            }


            otp.IsUsed = true;
            _otpRepo.Update(otp);



            result.IsSuccess = true;
            result.Data = otp;
            result.Message = _lexService.GetAlertSring("_otp_successfully_approved!", otpModel.CultureCode);
            return result;
        }
    }
}
