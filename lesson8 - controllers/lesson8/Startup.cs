using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace lesson8
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt => opt.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseMvc(routeBuilder =>
            routeBuilder.MapRoute("fileInfo", "{controller}/{action}", null, 
                                        new { controller = new StringRouteConstraint("File"), action = new StringRouteConstraint("ShowFile")}));

            app.UseMvc(routeBuilder =>
            routeBuilder.MapRoute("homepage", "{controller=File}/{action=DownloadFile}"));
        }
    }
}
