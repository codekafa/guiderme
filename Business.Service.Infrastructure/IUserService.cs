using DataModel.BaseEntities;
using System;
using System.Collections.Generic;
using ViewModel.Views;
using ViewModel.Views.Otp;
using ViewModel.Views.Security;
using ViewModel.Views.User;

namespace Business.Service.Infrastructure
{
    public interface IUserService
    {
        CommonResult GetUserList(UserSearchModel search);

        long GetUserListCount(UserSearchModel search);
        CommonResult AddOrEditUserForAdmin(AddOrEditUserModel user);

        bool IsExistMobileNumber(CheckUserModel checkModel);

        CommonResult UpdateUser(User user);

        CommonResult AddUser(User user);

        AddOrEditUserModel GetUserViewModel(long user_id);
        CommonResult RegisterNewUser(RegisterNewUserModel newUser);

        CommonResult ApproveMailOtp(CheckOtpCode request);

        CommonResult ApproveSmsOtp(CheckOtpCode request);

        CommonResult RegisterFacebookUser(RegisterNewUserModel newUser);
        User GetUserByID(long id);

        CommonResult UpdateUserForUI(AddOrEditUserModel user);

        CommonResult ChangePassword(ChangePasswordModel password);

        CommonResult SendForgotPasswordMail(ForgatPasswordModel mail);
        CommonResult ChangePasswordWithOtp(ChangePasswordModel request);

        CommonResult RegisterGoogleUser(RegisterNewUserModel newUser);

        bool IsExistEmailNumber(CheckUserModel checkModel);
    }
}
