using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Views;
using ViewModel.Views.Security;

namespace ServiceBuilderApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {

        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        private readonly ITokenEngine _tokenEngine;
        public UserController(IUserService userService, ITokenEngine tokenEngine, ISecurityService securityService)
        {
            _userService = userService;
            _tokenEngine = tokenEngine;
            _securityService = securityService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public CommonResult LoginUser(LoginUserModelView user)
        {
            var result = _tokenEngine.GetToken( new LoginUserModel { EmailOrPhone = user.EmailOrPhone, Password = user.Password });
            return result;
        }

        [HttpGet]
        [Route("getuserinfo")]
        public CommonResult GetUserInfo()
        {
            return new CommonResult();
        }

    }
}
