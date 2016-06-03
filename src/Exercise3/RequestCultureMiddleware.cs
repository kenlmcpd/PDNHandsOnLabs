using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;


namespace Exercise3
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestCultureOptions _options;
    
        public RequestCultureMiddleware(RequestDelegate next, RequestCultureOptions options)
        {
            this._next = next;
            _options = options;
        }

        public Task Invoke(HttpContext context)
        {
            public Task Invoke(HttpContext context)
        {
            CultureInfo requestCulture = null;

            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                requestCulture = new CultureInfo(cultureQuery);
            }
            else
            {
                requestCulture = _options.DefaultCulture;
            }

            if (requestCulture != null)
            {
#if !DNXCORE50
                Thread.CurrentThread.CurrentCulture = requestCulture;
                Thread.CurrentThread.CurrentUICulture = requestCulture;
#else
        CultureInfo.CurrentCulture = requestCulture;
        CultureInfo.CurrentUICulture = requestCulture;
#endif
            }

            return this._next(context);
        }
        }
    }

    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}