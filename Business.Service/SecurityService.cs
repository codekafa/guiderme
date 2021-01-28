using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Repository.Base;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using ViewModel.Views;
using ViewModel.Views.Security;
using ViewModel.Views.User;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class SecurityService : ISecurityService
    {
        ILexiconService _lexService;
        IHttpContextAccessor _contextAcc;
        IRequestService _requestService;
        IUnitOfWork _uow;
        IUserService _userService;
        public SecurityService(ILexiconService lexService, IHttpContextAccessor contextAccessor, IRequestService requestService, IUnitOfWork unitOfWork, IUserService userService)
        {
            _lexService = lexService;
            _contextAcc = contextAccessor;
            _requestService = requestService;
            _uow = unitOfWork;
            _userService = userService;
        }


        public CommonResult GetLoginUserWtihGoogle(LoginUserModel request)
        {            
            string googleToken = request.GoogleToken;

            string requestUrl = "https://oauth2.googleapis.com/tokeninfo?id_token=" + googleToken;

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(requestUrl);
            Request.Method = "GET";
            Request.KeepAlive = true;
            HttpWebResponse response = (HttpWebResponse)Request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {            
                Stream responseStream = response.GetResponseStream();
                string strStatus = ((HttpWebResponse)response).StatusDescription;
                StreamReader streamReader = new StreamReader(responseStream);
                string result  = streamReader.ReadToEnd();
                GoogleAuthReponse resultModel = JsonConvert.DeserializeObject<GoogleAuthReponse>(result);
                request.EmailOrPhone = resultModel.email;
                request.ProfilePhoto = resultModel.picture;
                request.Password = resultModel.sub;
                request.Name = resultModel.name;
                return LoginGoogle(request);
            }
            else
            {
                return new CommonResult(false, "Google token is not valid!");
            }
        }

        public CommonResult GetLoginUserWithFacebook(LoginUserModel request)
        {
            string facebookToken = request.FacebookToken;

            string requestUrl = "https://graph.facebook.com/me?fields=email,id,name&access_token=" + facebookToken;

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(requestUrl);
            Request.Method = "GET";
            Request.KeepAlive = true;
            HttpWebResponse response = (HttpWebResponse)Request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string strStatus = ((HttpWebResponse)response).StatusDescription;
                StreamReader streamReader = new StreamReader(responseStream);
                string result = streamReader.ReadToEnd();
                FacebookAuthModel resultModel = JsonConvert.DeserializeObject<FacebookAuthModel>(result);
                request.EmailOrPhone = resultModel.email;
                request.Password = resultModel.id;
                request.Name = resultModel.name;
                return LoginFacebook(request);
            }
            else
            {
                return new CommonResult(false, "Google token is not valid!");
            }
        }
        public CommonResult GetLoginUser(LoginUserModel request)
        {
            return LoginWeb(request);
        }

        public CommonResult LoginFacebook(LoginUserModel request)
        {
            CommonResult result = new CommonResult();
            var existUser = _uow.UserRepository.Get(x => (x.Email == request.EmailOrPhone || x.Phone == request.EmailOrPhone));

            if (existUser == null)
            {
                RegisterNewUserModel registerFacebook = new RegisterNewUserModel();
                registerFacebook.Email = request.EmailOrPhone;
                registerFacebook.Password = request.Password;
                registerFacebook.PasswordAgain = request.Password;
                registerFacebook.RegisterType = (int)UserTypes.Customer;
                registerFacebook.PhotoUrl = request.ProfilePhoto;
                if (!string.IsNullOrWhiteSpace(request.Name))
                {

                    if (request.Name.Contains(" "))
                    {
                        string[] name = request.Name.Split(" ");

                        for (int i = 0; i < name.Count(); i++)
                        {
                            if (i == 0)
                                registerFacebook.FirstName = name[i].ToString();
                            else
                                registerFacebook.LastName += name[i].ToString() + " ";

                        }
                    }
                    else
                    {
                        registerFacebook.FirstName = request.Name;
                    }
                }

                var registerFacebookResult = _userService.RegisterFacebookUser(registerFacebook);

                if (!registerFacebookResult.IsSuccess)
                    return registerFacebookResult;

                result.IsSuccess = true;
                result.Data = registerFacebookResult.Data;
                result.ActionCode = registerFacebookResult.ActionCode;
                return result;
            }
            else
            {
                if (request.RequestModel != null)
                {
                    if (!string.IsNullOrWhiteSpace(request.RequestModel.Description) && request.RequestModel.CategoryId > 0)
                    {
                        request.RequestModel.IsPublish = true;
                        request.RequestModel.UserId = existUser.ID;
                        _requestService.AddNewRequestWitoutTransaction(request.RequestModel);
                        result.ActionCode = "2";
                    }
                }
            }

            result.IsSuccess = true;
            result.Data = existUser;
            return result;
        }
        public CommonResult LoginGoogle(LoginUserModel request)
        {
            CommonResult result = new CommonResult();
            var existUser = _uow.UserRepository.Get(x => (x.Email == request.EmailOrPhone || x.Phone == request.EmailOrPhone));

            if (existUser == null)
            {
                RegisterNewUserModel registerGoogle = new RegisterNewUserModel();
                registerGoogle.Email = request.EmailOrPhone;
                registerGoogle.Password = request.Password;
                registerGoogle.PasswordAgain = request.Password;
                registerGoogle.RegisterType = (int)UserTypes.Customer;
                registerGoogle.PhotoUrl = request.ProfilePhoto;
                if (!string.IsNullOrWhiteSpace(request.Name))
                {

                    if (request.Name.Contains(" "))
                    {
                        string[] name = request.Name.Split(" ");

                        for (int i = 0; i < name.Count(); i++)
                        {
                            if (i == 0)
                                registerGoogle.FirstName = name[i].ToString();
                            else
                                registerGoogle.LastName += name[i].ToString() + " ";
                        }
                    }
                    else
                    {
                        registerGoogle.FirstName = request.Name;
                    }
                }

                var registerGoogleResult = _userService.RegisterGoogleUser(registerGoogle);

                if (!registerGoogleResult.IsSuccess)
                    return registerGoogleResult;

                result.IsSuccess = true;
                result.Data = registerGoogleResult.Data;
                result.ActionCode = registerGoogleResult.ActionCode;
                return result;
            }
            else
            {
                if (request.RequestModel != null)
                {
                    if (!string.IsNullOrWhiteSpace(request.RequestModel.Description) && request.RequestModel.CategoryId > 0)
                    {
                        request.RequestModel.IsPublish = true;
                        request.RequestModel.UserId = existUser.ID;
                        _requestService.AddNewRequestWitoutTransaction(request.RequestModel);
                        result.ActionCode = "2";
                    }
                }
            }

            result.IsSuccess = true;
            result.Data = existUser;
            return result;
        }
        public CommonResult LoginWeb(LoginUserModel request)
        {
            CommonResult result = new CommonResult();
            var existUser = _uow.UserRepository.Get(x => (x.Email == request.EmailOrPhone || x.Phone == request.EmailOrPhone) && x.Password == request.Password);

            if (existUser == null)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_user_not_found_for_login", request.CultureCode);
                return result;
            }

            if (!existUser.IsActive)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_user_passive_for_login", request.CultureCode);
                return result;
            }

            if (!existUser.IsMailActivated)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_user_not_active_for_mail_for_login", request.CultureCode);
                return result;
            }

            if (request.RequestModel != null)
            {
                if (!string.IsNullOrWhiteSpace(request.RequestModel.Description) && request.RequestModel.CategoryId > 0)
                {
                    request.RequestModel.IsPublish = true;
                    request.RequestModel.UserId = existUser.ID;
                    _requestService.AddNewRequest(request.RequestModel);
                    result.ActionCode = "2";
                }
            }

            result.IsSuccess = true;
            result.Data = existUser;
            return result;
        }

        public CurrentUserModel GetCurrentUser()
        {

            if (_contextAcc.HttpContext.User != null)
            {
                var claimId = _contextAcc.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                if (claimId == null)
                    return null;

                long userId = Convert.ToInt64(claimId.Value);
                var user = _uow.UserRepository.Get(x => x.IsActive == true && x.ID == userId);
                return new CurrentUserModel { FirstName = user.FirstName, ID = user.ID, IsMailActivation = user.IsMailActivated, LastName = user.LastName, ProfilePhoto = user.ProfilePhoto, IsMobileActivation = user.IsMobileActivated, UserType = user.UserType , WalletBalance = user.Balance};
            }
            else
            {
                return null;
            }

        }



    }
}
