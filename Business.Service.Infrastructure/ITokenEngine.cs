using ViewModel.Views;
using ViewModel.Views.Security;

namespace Business.Service.Infrastructure
{
    public interface ITokenEngine
    {
        CommonResult GetToken(LoginUserModel user);

        //string TokenEncryt(string token);

        //string TokenDecrypt(string token);

        //CommonResult DecryptToken(string token);
    }
}
