using Business.Service.Common;
using Business.Service.Infrastructure;
using GuiderMeApi.Attrubutes.BaseAttr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Core;
using ViewModel.Views;
using ViewModel.Views.Otp;
using ViewModel.Views.Security;

namespace GuiderMeApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenEngine _tokenEngine;
        public UserController(IUserService userService, ITokenEngine tokenEngine, ISecurityService securityService)
        {
            _userService = userService;
            _tokenEngine = tokenEngine;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public CommonResult LoginUser(LoginUserModelView user)
        {
            var result = _tokenEngine.GetToken(new LoginUserModel { EmailOrPhone = user.EmailOrPhone, Password = user.Password });
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("registeruser")]
        public CommonResult RegisterUser(RegisterNewUserModel newUser)
        {
            CommonResult result = new CommonResult();
            result = _userService.RegisterNewUser(newUser);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("approvemailotp")]
        public CommonResult ApproveEmailOtp(CheckOtpCode request)
        {
            request.CheckUsed = true;
            var result = _userService.ApproveMailOtp(request);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("approvesmsotp")]
        public CommonResult ApproveSmsOtp(CheckOtpCode request)
        {
            request.CheckUsed = true;
            var result = _userService.ApproveSmsOtp(request);
            return result;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("forgotpassword")]
        public CommonResult ForgotPassword(ForgatPasswordModel request)
        {
            var result = _userService.SendForgotPasswordMail(request);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("changepassword")]
        public CommonResult ChangePassword(ChangePasswordModel request)
        {
            var result = _userService.ChangePasswordWithOtp(request);
            return result;
        }

        [HttpGet]
        [Route("getuserinfo")]
        [ServiceFilter(typeof(ServiceMethodAuth))]
        public CommonResult GetUserInfo()
        {
            CommonResult result = new CommonResult();
            var ctx = IOC.resolve<IWebContext>();
            result.Data = ctx;
            return result;
        }

    }
}
