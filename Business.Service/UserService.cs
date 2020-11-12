﻿using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using ViewModel.Views;
using ViewModel.Views.Security;
using ViewModel.Views.User;
using static Common.Helpers.Enum;

namespace Business.Service
{

    public class UserService : IUserService
    {
        IUserRepository _userRepo;
        IUserAddressRepository _userAddressRepo;
        IQuerableRepository _queryRepo;
        IFileService _fileService;
        public UserService(IUserRepository userRepo, IUserAddressRepository userAddressRepo, IQuerableRepository queryRepo, IFileService fileService)
        {
            _userRepo = userRepo;
            _userAddressRepo = userAddressRepo;
            _queryRepo = queryRepo;
            _fileService = fileService;
        }

        public AddOrEditUserModel GetUserViewModel(long user_id)

        {
            AddOrEditUserModel result = new AddOrEditUserModel();
            var existUser = _userRepo.Get(x => x.ID == user_id);
            result.FirstName = existUser.FirstName;
            result.Email = existUser.Email;
            result.ID = existUser.ID;
            result.IsMailActivated = existUser.IsMailActivated;
            result.IsMobileActivated = existUser.IsMobileActivated;
            result.LastName = existUser.LastName;
            result.Password = existUser.Password;
            result.Phone = existUser.Phone;
            result.PhotoUrl = existUser.ProfilePhoto;
            return result;

        }
        public CommonResult AddOrEditUserForAdmin(AddOrEditUserModel user)
        {
            var result = new CommonResult();
            var existUser = new User();
            existUser.ID = user.ID;

            bool check = IsExistMobileNumber(new CheckUserModel { Email = user.Email, Mobile = user.Phone, ID = user.ID });

            if (check)
            {
                result.IsSuccess = false;
                result.Message = "User already exist with email or phone number!";
                return result;
            }

            if (user.Photo != null)
            {
                string path = _fileService.SaveImage(user.Photo, FileTypes.ProfileFiles).Data.ToString();
                existUser.ProfilePhoto = path;
            }
            else
            {
                existUser.ProfilePhoto = user.PhotoUrl;
            }

            existUser.FirstName = user.FirstName;
            existUser.Email = user.Email;
            existUser.IsActive = true;
            existUser.IsMailActivated = user.IsMailActivated;
            existUser.IsMobileActivated = user.IsMobileActivated;
            existUser.LastName = user.LastName;
            existUser.Password = user.Password;
            existUser.Phone = user.Phone;
            existUser.UserType = (int)UserTypes.Customer;

            if (existUser.ID > 0)
                result = UpdateUser(existUser);
            else
                result = AddUser(existUser);

            result.IsSuccess = true;
            return result;
        }
        public CommonResult UpdateUser(User user)
        {
            CommonResult result = new CommonResult();
            var saveResult = _userRepo.Update(user);
            result.Data = saveResult;
            result.IsSuccess = true;
            return result;
        }
        public CommonResult AddUser(User user)
        {
            CommonResult result = new CommonResult();
            var saveResult = _userRepo.Add(user);
            result.Data = saveResult;
            result.IsSuccess = true;
            return result;
        }
        public List<UserListModel> GetUserList(UserSearchModel search)
        {
            var list = _queryRepo.GetList<UserListModel>(@"select * from users where
                                                                IsActive = 1
                                                                and(@IsMailActivated is null or IsMailActivated = @IsMailActivated)
                                                                and(@IsMobileActivated is null or IsmobileActivated = @IsMobileActivated)
                                                                and(@Email is null or Email = @Email)", search);

            return list;

        }
        public long GetUserListCount(UserSearchModel search)
        {
            var count = _queryRepo.GetSingle<long>(@"select COunt(*) from users where
                                                                IsActive = 1
                                                                and(@IsMailActivated is null or IsMailActivated = @IsMailActivated)
                                                                and(@IsMobileActivated is null or IsmobileActivated = @IsMobileActivated)
                                                                and(@Email is null or Email = @Email)", search);

            return count;
        }

        public bool IsExistMobileNumber(CheckUserModel checkModel)
        {
            int count = _queryRepo.GetSingle<int>(@"select COUNT(*) from users
                                                         where IsActive = 1  and ID != @ID
                                                        and ((@Email is null or Email = @Email)
                                                        OR (@Mobile is null or Phone = @Mobile))", checkModel);

            return count > 0;
        }

    }
}
