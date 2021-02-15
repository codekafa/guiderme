using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ViewModel.Core;
using ViewModel.Views;
using ViewModel.Views.Security;

namespace Business.Service.Common
{
    public class TokenService : ITokenEngine
    {
        ISecurityService _securService;
        public TokenService(ISecurityService securService)
        {
            _securService = securService;
        }

        public TokenService()
        {
        }

        public Dictionary<string, string> Claims { get; private set; }

        string TokenModel = @"UID@value@UID~ID@value@ID~CID@value@CID~AID@value@AID~ROLS@value@ROLS";

        public CommonResult GetToken(LoginUserModel user)
        {

            var loginResult = _securService.GetLoginUser(user);

            if (!loginResult.IsSuccess)
                return loginResult;

            var userEntity = loginResult.Data as User;

            var tokenModel = TokenModel;
            string guidId = Guid.NewGuid().ToString();
            tokenModel  = tokenModel.Replace("ID@value@ID", $"ID@{guidId}@ID");
            tokenModel = tokenModel.Replace("UID@value@UID", $"UID@{userEntity.ID}@UID");
            tokenModel = tokenModel.Replace("AID@value@AID", $"AID@{userEntity.IsMobileActivated}@AID");
            tokenModel = tokenModel.Replace("ROLS@value@ROLS", $"ROLS@{1}@ROLS");

            var accessToken = new TokenResponseModel();
            accessToken.Token = TokenEncryt(tokenModel);
            accessToken.ExpireDate = DateTime.Now.AddDays(1);

            var context =  IOC.resolve<IWebContext>();
            context.IsActivedUser = userEntity.IsMobileActivated.ToString();
            context.UserID = userEntity.ID.ToString();
            context.UserRoles = "1";

            return new CommonResult { IsSuccess = true, Data = accessToken };
        }

        public string TokenEncryt(string token)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(token);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("Sc-Builder123@545"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public string TokenDecrypt(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("Sc-Builder123@545"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        public CommonResult DecryptToken(string token)
        {
            string tokenResult = TokenDecrypt(token);

            WebContext result = new WebContext();
            result.UserID = getBetween(tokenResult, "UID@", "@UID");
            result.ChannelID = getBetween(tokenResult, "CID@", "@CID");
            result.IsActivedUser = getBetween(tokenResult, "AID@", "@AID");

            return new CommonResult { IsSuccess = false, Data = result };
        }
        public string getBetween(string source, string startStr, string endStr)
        {
            int start, end;
            start = source.IndexOf(startStr, 0) + startStr.Length;
            end = source.IndexOf(endStr, start);
            string find = source.Substring(start, end - start);
            return find;
        }
    }
}
