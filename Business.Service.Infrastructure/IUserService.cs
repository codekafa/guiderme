using DataModel.BaseEntities;
using System;
using System.Collections.Generic;
using ViewModel.Views;
using ViewModel.Views.Security;
using ViewModel.Views.User;

namespace Business.Service.Infrastructure
{
    public interface IUserService
    {
        List<UserListModel> GetUserList(UserSearchModel search);

        long GetUserListCount(UserSearchModel search);
        CommonResult AddOrEditUserForAdmin(AddOrEditUserModel user);

        bool IsExistMobileNumber(CheckUserModel checkModel);

        CommonResult UpdateUser(User user);

        CommonResult AddUser(User user);

        AddOrEditUserModel GetUserViewModel(long user_id);
    }
}
