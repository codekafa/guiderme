using Business.Service.Infrastructure;
using GuiderMeApi.Attrubutes.BaseAttr;
using Microsoft.AspNetCore.Mvc;
using System;
using ViewModel.Views;
using ViewModel.Views.Security;
using ViewModel.Views.User;

namespace GuiderMeApi.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [ServiceFilter(typeof(ServiceMethodAuth))]
    public class ProfileController : BaseController
    {
        IUserService _userService;
        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getprofile")]
        public CommonResult GetProfile()
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            result.Data = _userService.GetCurrentUserViewModel();
            return result;
        }

        [HttpPost]
        [Route("updateprofile")]
        public CommonResult UpdateProfile(AddOrEditUserModel request)
        {
            request.CurrentUserId = CurrentUserID;
            var result = _userService.UpdateUserForUI(request);
            return result;
        }

        [HttpPost]
        [Route("changepassword")]
        public CommonResult ChangePassword(ChangePasswordModel request)
        {
            request.CurrentUserId = CurrentUserID;
            var result = _userService.ChangePassword(request);
            return result;
        }

    }
}
