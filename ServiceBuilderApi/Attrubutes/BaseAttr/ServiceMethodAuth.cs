using Business.Service.Common;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ViewModel.Core;

namespace GuiderMeApi.Attrubutes.BaseAttr
{
    public class ServiceMethodAuth : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if (context != null && context.HttpContext.Request.Headers["Authorization"].Count <= 0)
            {
                context.HttpContext.Response.StatusCode = 401;
            }
            else
            {
                var webContext = IOC.resolve<IWebContext>();

                var tokenEngine = IOC.resolve<ITokenEngine>();

                var tokenModel = tokenEngine.DecryptToken(context.HttpContext.Request.Headers["Authorization"].ToString());

                var viewContext = tokenModel.Data as WebContext;

                var scopeContext = IOC.resolve<IWebContext>();

                scopeContext = viewContext;
                var result = await next();
            }
        }
    }
}
