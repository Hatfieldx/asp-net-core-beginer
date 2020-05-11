using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;


namespace lesson5
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt=>opt.EnableEndpointRouting = false);
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.UseRouting();

            app.UseMvc(
                rbuilder =>
                rbuilder.MapRoute("default", "{controller}/{action}/{id?}", 
                defaults: new { action = "Index" },
                constraints: new {controller = new  StringRouteConstraint("Home")})
                );        
         }
    }
}
