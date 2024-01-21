using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace PaparaApp.API.Filters
{
    public class IPCheckActionFilter : Attribute, IActionFilter
    {
        private static readonly List<IPAddress> whiteListIpAddress =
        [
            IPAddress.Parse("127.0.0.1"),
            IPAddress.Parse("::1")
        ];
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var ipAdsress = context.HttpContext.Connection.RemoteIpAddress;
            if (!whiteListIpAddress.Contains(ipAdsress))
            {
                context.Result = new ContentResult()
                {
                    Content = "IP Adresiniz Yetkili Değil!",
                    StatusCode = 401
                };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
