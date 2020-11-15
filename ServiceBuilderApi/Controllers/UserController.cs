using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using ViewModel.Views;
using ViewModel.Views.Otp;
using ViewModel.Views.Security;

namespace ServiceBuilderApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {

        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        private readonly ITokenEngine _tokenEngine;
        public UserController(IUserService userService, ITokenEngine tokenEngine, ISecurityService securityService)
        {
            _userService = userService;
            _tokenEngine = tokenEngine;
            _securityService = securityService;
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


        [HttpGet]
        [Route("getuserinfo")]
        public CommonResult GetUserInfo()
        {
            CommonResult result = new CommonResult();
            var existUserId = Request.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            long user_id = Convert.ToInt64(existUserId.Value);
            result.Data = _userService.GetUserViewModel(user_id);

            return result;
        }

    }
}
