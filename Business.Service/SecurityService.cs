using Business.Service.Infrastructure;
using Repository.Base;
using ViewModel.Views;
using ViewModel.Views.Security;

namespace Business.Service
{
    public class SecurityService : ISecurityService
    {
        IUserRepository _userRepo;
        ILexiconService _lexService;
        public SecurityService(IUserRepository userRepo, ILexiconService lexService)
        {
            _userRepo = userRepo;
            _lexService = lexService;
        }

        public CommonResult GetLoginUser(LoginUserModel request)
        {
            CommonResult result = new CommonResult();

            var existUser = _userRepo.Get(x => (x.Email == request.EmailOrPhone || x.Phone == request.EmailOrPhone) && x.Password == request.Password);

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

            if (!existUser.IsMobileActivated)
            {
                result.IsSuccess = false;
                result.Message = _lexService.GetAlertSring("_user_not_active_for_mobile_phonee_for_login", request.CultureCode);
                return result;
            }

            return new CommonResult { Data = existUser, IsSuccess = true };
        }
    }
}
