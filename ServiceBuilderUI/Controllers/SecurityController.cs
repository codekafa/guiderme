using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel.Views;
using ViewModel.Views.Otp;
using ViewModel.Views.Security;

namespace ServiceBuilderUI.Controllers
{
    public class SecurityController : Controller
    {

        IUserService _userService;
        ISecurityService _securityService;
        public SecurityController(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel user)
        {
            var loginResult = _securityService.GetLoginUser(user);

            if (loginResult.IsSuccess)
            {
                var userModel = loginResult.Data as User;
                var claims = new List<Claim>
                                    {
                                        new Claim(ClaimTypes.Role, userModel.UserType.ToString()),
                                        new Claim(ClaimTypes.Name, userModel.Email),
                                        new Claim(ClaimTypes.NameIdentifier,userModel.ID.ToString())
                                    };

                var userIdentity = new ClaimsIdentity(claims, "Bearer");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return Json(loginResult);
            }
            else
            {
                return Json(loginResult);
            }
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("login");
        }

        [HttpPost]
        public CommonResult RegisterUser(RegisterNewUserModel newUser)
        {
            CommonResult result = new CommonResult();
            result = _userService.RegisterNewUser(newUser);
            return result;
        }


        [Route("email-approve")]
        public IActionResult ApproveEmail()
        {
            return View();
        }

        [HttpPost]
        public CommonResult ApproveOtp(ApproveOtpModel request)
        {
            CommonResult result = new CommonResult();

            if (request.OtpType == (int)Common.Helpers.Enum.OTPTypes.EmailOTP)
            {
                result = _userService.ApproveMailOtp(new CheckOtpCode { CheckUsed = true, OtpCode = request.OtpCode });
            }
            else
            {
                result = _userService.ApproveSmsOtp(new CheckOtpCode { CheckUsed = true, OtpCode = request.OtpCode });
            }
            return result;
        }

    }
}
