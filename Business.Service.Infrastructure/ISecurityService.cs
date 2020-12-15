using ViewModel.Views;
using ViewModel.Views.Security;
using ViewModel.Views.User;

namespace Business.Service.Infrastructure
{
    public interface ISecurityService
    {

        CommonResult GetLoginUser(LoginUserModel request);

        CommonResult GetLoginUserWithFacebook(LoginUserModel request);
        CommonResult GetLoginUserWtihGoogle(LoginUserModel request);
        CurrentUserModel GetCurrentUser();
    }
}
