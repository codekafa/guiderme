using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Http;
using Repository.Base;
using System;
using System.Linq;
using System.Security.Claims;
using ViewModel.Views;
using ViewModel.Views.Security;
using ViewModel.Views.User;

namespace Business.Service
{
    public class SecurityService : ISecurityService
    {
        ILexiconService _lexService;
        IHttpContextAccessor _contextAcc;
        IRequestService _requestService;
        IUnitOfWork _uow;
        public SecurityService( ILexiconService lexService, IHttpContextAccessor contextAccessor, IRequestService requestService, IUnitOfWork unitOfWork)
        {
            _lexService = lexService;
            _contextAcc = contextAccessor;
            _requestService = requestService;
            _uow = unitOfWork;
        }

        public CommonResult GetLoginUser(LoginUserModel request)
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


            return new CommonResult { Data = existUser, IsSuccess = true };
        }

        public CurrentUserModel GetCurrentUser()
        {

            if (_contextAcc.HttpContext.User != null)
            {
                var  claimId = _contextAcc.HttpContext.User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                if (claimId == null)
                    return null;

                long userId = Convert.ToInt64(claimId.Value);
                var user = _uow.UserRepository.Get(x => x.IsActive == true && x.ID == userId);
                return new CurrentUserModel { FirstName = user.FirstName, ID = user.ID, IsMailActivation = user.IsMailActivated, LastName = user.LastName, ProfilePhoto = user.ProfilePhoto, IsMobileActivation = user.IsMobileActivated, UserType = user.UserType };
            }
            else
            {
                return null;
            }

        }



    }
}
