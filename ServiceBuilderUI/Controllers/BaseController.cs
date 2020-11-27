using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceBuilderUI.Controllers
{
    public class BaseController : Controller
    {
        public long? CurrentUserId
        {
            get
            {
                var currentUser = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                if (currentUser != null)
                {
                    long userId = Convert.ToInt64(currentUser.Value);
                    return userId;
                }
                return null;

            }
        }
        public string CurrentUserEmail
        {
            get
            {
                var currentUser = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();

                if (currentUser != null)
                {
                    string email = currentUser.Value;
                    return email;
                }
                return null;

            }
        }
    }
}
