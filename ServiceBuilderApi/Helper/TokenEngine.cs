using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceBuilderApi.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Views;
using ViewModel.Views.Security;

namespace ServiceBuilderApi.Helper
{
    public class TokenEngine : ITokenEngine
    {
        ISecurityService _userService;
        AppSettings _appSettings;
        public TokenEngine(ISecurityService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        public CommonResult GetToken(LoginUserModel user)
        {

            TokenResultModel result = new TokenResultModel();

            var userResult = _userService.GetLoginUser(user);

            if (!userResult.IsSuccess)
                return userResult;

            var tokenResult = userResult.Data as User;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, tokenResult.FirstName.ToString() + " " + tokenResult.LastName),
                     new Claim(ClaimTypes.Email, tokenResult.Email.ToString()),
                                 new Claim(ClaimTypes.NameIdentifier, tokenResult.ID.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.Token = tokenHandler.WriteToken(token);
            result.FullName = tokenResult.FirstName.ToString() + " " + tokenResult.LastName;
            return new CommonResult { IsSuccess = false, Data = tokenResult };
        }

    }
}
