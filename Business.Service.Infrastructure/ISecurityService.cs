using ViewModel.Views;
using ViewModel.Views.Security;

namespace Business.Service.Infrastructure
{
    public interface ISecurityService
    {

        CommonResult GetLoginUser(LoginUserModel request);
    }
}
