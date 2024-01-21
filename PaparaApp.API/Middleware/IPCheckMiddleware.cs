using System.Net;

namespace PaparaApp.API.Middleware
{
    public class IPCheckMiddleware(RequestDelegate next)
    {
        private static readonly List<IPAddress> whiteListIpAddress =
        [
            IPAddress.Parse("127.0.0.1"),
            IPAddress.Parse("::1")
        ];
        public async Task InvokeAsync(HttpContext context)
        {
            var ipAdsress = context.Connection.RemoteIpAddress;

            if (context.Request.Path.Value.Contains("swagger",StringComparison.OrdinalIgnoreCase))
            {
                await next(context);
                return;
            }
            if (whiteListIpAddress.Contains(ipAdsress))
            {
                await next(context);
            }
            else
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("IP Adresiniz Yetkili Değil!");
            }
        }
    }
}
