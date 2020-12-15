using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderUI.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel.Views;
using ViewModel.Views.Otp;
using ViewModel.Views.Security;

namespace ServiceBuilderUI.Controllers
{
    public class SecurityController : BaseController
    {

        IUserService _userService;
        ISecurityService _securityService;
        IOtpService _otpService;
        public SecurityController(IUserService userService, ISecurityService securityService, IOtpService otpService)
        {
            _userService = userService;
            _securityService = securityService;
            _otpService = otpService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }


        [Route("register-user")]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [Route("register-provider")]
        public IActionResult RegisterProvider()
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
                loginResult.Data = null;
                return Json(loginResult);
            }
            else
            {
                return Json(loginResult);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginWithGoogle(LoginUserModel user)
        {
            var loginResult = _securityService.GetLoginUserWtihGoogle(user);

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
                loginResult.Data = null;
                return Json(loginResult);
            }
            else
            {
                return Json(loginResult);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginWithFacebook(LoginUserModel user)
        {
            var loginResult = _securityService.GetLoginUserWithFacebook(user);

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
                loginResult.Data = null;
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

            return View();
        }


        [AuthorizeCustom]
        [Route("/api/logout")]
        [HttpPost]
        public async void LogoutUser()
        {
            await HttpContext.SignOutAsync();

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


        [Route("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public CommonResult SendChangePasswordMail(ForgatPasswordModel mail)
        {
            CommonResult result = new CommonResult();
            result = _userService.SendForgotPasswordMail(mail);
            return result;
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

        [Route("change-password/{otp_code}")]
        public IActionResult ChangePassword(string otp_code)
        {
            bool check = _otpService.CheckOtpCode(otp_code);
            if (!check)
                return Redirect("/login");
            ViewBag.OtpCode = otp_code;
            return View();
        }

        public CommonResult ChangePasswordWithOtp(ChangePasswordModel request)
        {
            CommonResult result = new CommonResult();
            result = _userService.ChangePasswordWithOtp(request);
            return result;

        }

    }
}
