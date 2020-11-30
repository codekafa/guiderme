using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using ViewModel.Views;
using ViewModel.Views.Otp;
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
        ILexiconService _lexService;
        IOtpService _otpService;
        public UserService(IUserRepository userRepo, IUserAddressRepository userAddressRepo, IQuerableRepository queryRepo, IFileService fileService, ILexiconService lexService, IOtpService otpServicce)
        {
            _userRepo = userRepo;
            _userAddressRepo = userAddressRepo;
            _queryRepo = queryRepo;
            _fileService = fileService;
            _lexService = lexService;
            _otpService = otpServicce;
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
            result.UserType = existUser.UserType;
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
        public User GetUserByID(long id)
        {
            return _userRepo.Get(x => x.ID == id);
        }
        public CommonResult UpdateUserForUI(AddOrEditUserModel user)
        {
            var result = new CommonResult();
            var existUser = new User();

            existUser = GetUserByID(user.ID);

            if (existUser == null)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_user_not_found", null);
                return result;
            }

            bool check = IsExistMobileNumber(new CheckUserModel { Email = user.Email, Mobile = user.Phone, ID = user.ID });

            if (check)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_user_alreay_exist_with_eail_or_phone", null);
                return result;
            }

            if (user.Photo != null)
            {
                string path = _fileService.SaveImage(user.Photo, FileTypes.ProfileFiles).Data.ToString();
                existUser.ProfilePhoto = path;
            }

            existUser.FirstName = user.FirstName;
            existUser.Email = user.Email;
            existUser.LastName = user.LastName;
            existUser.Password = user.Password;
            existUser.Phone = user.Phone;
            existUser.UserType = user.UserType;
            result = UpdateUser(existUser);
            result.IsSuccess = true;

            if (existUser.Email != user.Email)
                result.ActionCode = "1";

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
        public CommonResult GetUserList(UserSearchModel search)
        {
            CommonResult result = new CommonResult();

            string query = @"select * from users where
                                                                IsActive = 1
                                                                and(@IsMailActivated is null or IsMailActivated = @IsMailActivated)
                                                                and(@IsMobileActivated is null or IsmobileActivated = @IsMobileActivated)
                                                                and(@Email is null or Email = @Email)";

            query += " LIMIT " + search.PageIndex * 20 + ",20";


            var list = _queryRepo.GetList<UserListModel>(query, search);


            result.IsSuccess = true;
            result.Data = list;
            result.DataCount = GetUserListCount(search);
            result.SelectedPage = search.PageIndex;

            long k = result.DataCount.Value % 10;

            if (k > 0)
                result.PageCount = (result.DataCount / 20) + 1;
            else
                result.PageCount = result.DataCount;

            return result;

        }
        public long GetUserListCount(UserSearchModel search)
        {
            var count = _queryRepo.GetSingle<long>(@"select COunt(ID) from users where
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
        public CommonResult RegisterNewUser(RegisterNewUserModel newUser)
        {
            CommonResult result = new CommonResult();
            try
            {
                result = RegisterUserValidate(newUser);

                if (!result.IsSuccess)
                    return result;

                var addUser = _userRepo.Add(new User { Email = newUser.Email, IsActive = true, IsMailActivated = false, IsMobileActivated = false, Phone = newUser.Phone, UserType = newUser.RegisterType, Password = newUser.Password });

                var otpResult = _otpService.CreateNewOtp(new CreateOtpModel { CurrentUserId = addUser.ID, EmailOrPhone = addUser.Email, OtpType = (int)OtpTypes.Email });

                result.IsSuccess = true;
                result.Data = otpResult.Data.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Data = ex;
            }
            return result;
        }
        public CommonResult RegisterUserValidate(RegisterNewUserModel newUser)
        {
            CommonResult result = new CommonResult();

            if (string.IsNullOrWhiteSpace(newUser.Email))
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_email_is_reqired", newUser.CultureCode);
                return result;
            }
            if (string.IsNullOrWhiteSpace(newUser.Phone))
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_mobile_phone_is_reqired", newUser.CultureCode);
                return result;
            }
            if (string.IsNullOrWhiteSpace(newUser.Password))
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_password_is_reqired", newUser.CultureCode);
                return result;
            }

            if (string.IsNullOrWhiteSpace(newUser.PasswordAgain))
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_password_again_is_reqired", newUser.CultureCode);
                return result;
            }

            bool check = IsExistMobileNumber(new CheckUserModel { Email = newUser.Email, Mobile = newUser.Phone });

            if (check)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_already_exist_this_email_or_phone_user", newUser.CultureCode);
                return result;
            }


            if (newUser.Password != newUser.PasswordAgain)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_passwords_not_correct", newUser.CultureCode);
                return result;
            }

            result.IsSuccess = true;
            return result;
        }

        public CommonResult ApproveMailOtp(CheckOtpCode request)
        {
            var result = _otpService.ApproveOtp(request);

            var otp = result.Data as OtpTransaction;

            if (!result.IsSuccess)
                return result;


            var user = _userRepo.Get(x => x.ID == otp.UserID);
            user.IsMailActivated = true;
            _userRepo.Update(user);
            return result;
        }

        public CommonResult ApproveSmsOtp(CheckOtpCode request)
        {
            var result = _otpService.ApproveOtp(request);

            var otp = result.Data as OtpTransaction;

            if (!result.IsSuccess)
                return result;


            var user = _userRepo.Get(x => x.ID == otp.UserID);
            user.IsMobileActivated = true;
            _userRepo.Update(user);
            return result;
        }

        public CommonResult ChangePassword(ChangePasswordModel password)
        {
            CommonResult result = new CommonResult();
            try
            {

                if (password.Password != password.PasswordAgain)
                {
                    result.IsSuccess = false;
                    result.Message = _lexService.GetAlertSring("_password_not_same", null);
                    return result;
                }

                var user = GetUserByID(password.CurrentUserId);

                if (password.CurrentPassword != user.Password)
                {
                    result.IsSuccess = false;
                    result.Message = _lexService.GetAlertSring("_current_password_not_same", null);
                    return result;
                }

                user.Password = password.Password;
                _userRepo.Update(user);

                result.IsSuccess = true;
                result.Message = _lexService.GetAlertSring("_success_passwoord_changed", null);
                return result;


            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public CommonResult SendForgotPasswordMail(ForgatPasswordModel mail)
        {
            CommonResult result = new CommonResult();
            var existEmail = _userRepo.Get(x => x.IsActive && x.Email == mail.Email);

            if (existEmail == null)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_user_not_found_for_change_password_mail", null);
                return result;
            }

            var otpResult = _otpService.CreateNewOtp(new CreateOtpModel { CurrentUserId = existEmail.ID, EmailOrPhone = existEmail.Email, OtpType = (int)OtpTypes.ChangePassword });

            if (!otpResult.IsSuccess)
                return otpResult;

            return result;

        }


        public CommonResult ChangePasswordWithOtp(ChangePasswordModel request)
        {

            CommonResult result = new CommonResult();

            if (request.Password != request.PasswordAgain)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_password_not_same", null);
                return result;
            }

            var otpResult = _otpService.GetOtpResult(request.OtpCode, (int)OtpTypes.ChangePassword);

            if (otpResult.IsSuccess)
            {

                var otpTransaction = otpResult.Data as OtpTransaction;

                if (!otpTransaction.IsActive || !otpTransaction.IsUsed)
                {
                    result.IsSuccess = false;
                    result.Message = _lexService.GetAlertSring("_otp_code_not_found", null);
                    return result;
                }
                else
                {

                    var user = _userRepo.Get(x => x.ID == otpTransaction.UserID);
                    user.Password = request.Password;
                    _userRepo.Update(user);
                    result.IsSuccess = true;
                    result.Message = _lexService.GetAlertSring("_password_change_successfuly", null);
                    return result;
                }
            }
            else
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_otp_code_not_found", null);
                return result;
            }         
        }


    }
}
