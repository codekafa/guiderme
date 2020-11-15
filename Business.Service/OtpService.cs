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
        IOtpTransactionRepository _otpRepo;
        IMailService _mailService;
        ISmsService _smsService;
        IQuerableRepository _queryRepo;
        ILexiconService _lexService;
        public OtpService(IOtpTransactionRepository otpRepo, IMailService mailService, ISmsService smsService, IQuerableRepository queryRepo, ILexiconService lexService)
        {
            _otpRepo = otpRepo;
            _mailService = mailService;
            _smsService = smsService;
            _queryRepo = queryRepo;
            _lexService = lexService;
        }

        public CommonResult CreateNewOtp(CreateOtpModel request)
        {
            CommonResult result = new CommonResult();
            CommonResult otpResult = new CommonResult();

            string otp = GetOrpCode();
            var newOtp = _otpRepo.Add(new OtpTransaction { ExpireDate = DateTime.Now.AddDays(1), IsActive = true, IsUsed = false, OTPCode = otp, OTPType = request.OtpType, UserID = request.CurrentUserId });

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
            CommonResult result = new CommonResult();
            //result = _mailService.Send(new ViewModel.Views.Mail.SendEmailModel { });
            result.IsSuccess = true;
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

            if (otp.ExpireDate > DateTime.Now)
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
