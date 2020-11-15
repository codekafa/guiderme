using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceBuilderPanel.Models
{
    public class AuthorizeCustom : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {

            if (filterContext != null)
            {
                if (filterContext.HttpContext != null && filterContext.HttpContext.User != null)
                {

                    if (filterContext.HttpContext.Request.Cookies[".AspNetCore.Cookies"] != null)
                    {
                        var cookie = filterContext.HttpContext.Request.Cookies[".AspNetCore.Cookies"].ToString();
                        var claimId = filterContext.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                        if (claimId != null)
                        {
                            filterContext.HttpContext.Response.StatusCode = 200;
                            return;
                        }
                    }
                    filterContext.Result = new RedirectResult("/Account/Login");
                };
                return;
            }
            else
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                filterContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Please Provide authToken";
                filterContext.Result = new JsonResult("Please Provide authToken")
                {
                    Value = new
                    {
                        Status = "Error",
                        Message = "Please Provide authToken"
                    },
                };
            }
        }

    }
}
