using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseIISPlatformHandler();

    //        app.Use((context, next) =>
    //        {
    //            var cultureQuery = context.Request.Query["culture"];
    //            if (!string.IsNullOrWhiteSpace(cultureQuery))
    //            {
    //                var culture = new CultureInfo(cultureQuery);
    //#if !DNXCORE50
    //            Thread.CurrentThread.CurrentCulture = culture;
    //            Thread.CurrentThread.CurrentUICulture = culture;
    //#else
    //            CultureInfo.CurrentCulture = culture;
    //            CultureInfo.CurrentUICulture = culture;
    //#endif
    //             }

    //            // Call the next delegate/middleware in the pipeline
    //            return next();
    //        });

            app.UseRequestCulture();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello {CultureInfo.CurrentCulture.DisplayName}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
