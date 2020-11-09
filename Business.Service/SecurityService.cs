using Business.Service.Infrastructure;
using Repository.Base;
using ViewModel.Views;
using ViewModel.Views.Security;

namespace Business.Service
{
    public class SecurityService : ISecurityService
    {
        IUserRepository _userRepo;
        ILexiconRepository _lexRepo;
        public SecurityService(IUserRepository userRepo, ILexiconRepository lexRepo)
        {
            _userRepo = userRepo;
            _lexRepo = lexRepo;
        }

        public CommonResult GetLoginUser(LoginUserModel request)
        {

            var existUser = _userRepo.Get(x => (x.Email == request.EmailOrPhone || x.Phone == request.EmailOrPhone) && x.Password == request.Password);

            if (existUser == null)
                return new CommonResultHelper(_lexRepo).GetAlertResult(false, "_user_not_found", request.CultureCode);

            if (!existUser.IsActive)
                return new CommonResultHelper(_lexRepo).GetAlertResult(false, "_user_passive", request.CultureCode);

            if (!existUser.IsMobileActivated)
                return new CommonResultHelper(_lexRepo).GetAlertResult(false, "_user_not_active_for_mobile", request.CultureCode);

            return new CommonResult { Data = existUser, IsSuccess = true };
        }
    }
}
