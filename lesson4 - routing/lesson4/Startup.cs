using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;

namespace lesson4
{
    public class Startup
    {
        IConfiguration _configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfiguration>(provider => _configuration);
            services.Configure<Library>(_configuration);
            services.AddOptions<Library>();
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //RouteHandler libraryHandler = new RouteHandler(LibraryHandlerAsync);

            RouteBuilder libraryRouteBuilder = new RouteBuilder(app);

            libraryRouteBuilder.MapRoute("Library", async context =>
                                        await context.Response.WriteAsync("Hello from Base Library"));

            libraryRouteBuilder.MapRoute("Library/Books", ShowListAsync);

            libraryRouteBuilder.MapRoute("Library/Profile/{id:range(0, 5)?}", ShowProfileInfo);

            app.UseRouter(libraryRouteBuilder.Build());
            ///tasks 1-3
            RouteHandler baseRouteHandler = new RouteHandler(BaseHandlerAsync);

            RouteBuilder routeBuilder = new RouteBuilder(app, baseRouteHandler);

            routeBuilder.MapRoute("default", "{controller:int}/{action:int}/{id:int}");

            app.UseRouter(routeBuilder.Build());

            RouteHandler catchHandler = new RouteHandler(CatchHandlerAsync);

            RouteBuilder routeBuilderCatch = new RouteBuilder(app, catchHandler);
                                    
            routeBuilderCatch.MapRoute("default_catch", "{*catchall}");

            app.UseRouter(routeBuilderCatch.Build());

        }

        private async Task ShowProfileInfo(HttpContext context)
        {
            string id = context.GetRouteValue("id")?.ToString();

            if (string.IsNullOrEmpty(id))
                await context.Response.WriteAsync("Information about youself");

            var accountsArray = context.RequestServices.GetService<IConfiguration>()?.GetSection("accounts")?.GetChildren();

            StringBuilder sb1 = new StringBuilder("Profile: ");

            Dictionary<string, string> accs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            string idt = "";
            string name = "";

            foreach (var account in accountsArray)
            {
                if (account.Value == null)
                {
                    foreach (var item in account.GetChildren())
                    {                 
                        if (item.Key == "id")
                            idt = item.Value;
                        else if (item.Key == "name")
                            name = item.Value;
                    }
                    accs.Add(idt, name);
                }
            }

            if(accs.ContainsKey(id))            
                await context.Response.WriteAsync($"<h1>Profile: </h1> <p>{accs[id]}</p>");
            else
                await context.Response.WriteAsync($"<h1>Profile: </h1> <p>Information about youself</p>");

            //if (accounts != null)
            //{
            //    StringBuilder sb = new StringBuilder("Profile: ");

            //    string acc = (from profile in accounts.GetChildren() where profile["id"] == id select profile["name"]).SingleOrDefault();

            //    if (!string.IsNullOrEmpty(acc))
            //        await context.Response.WriteAsync($"<h1>Profile: </h1> <p>{acc}</p>");
            //}

        }

        private async Task ShowListAsync(HttpContext contex)
        {
            IOptions<Library> opt = contex.RequestServices.GetService<IOptions<Library>>();

            Library lib = opt.Value;

            if (lib == null || lib.Books.Count == 0)
                await contex.Response.WriteAsync("Books list is empty");

            StringBuilder sb = new StringBuilder("<h1>Books list:</h1>");
            
            foreach (var item in lib.Books)
            {
                sb.Append($"<br> name: {item.Name} author: {item.Author}");
            }
            
            await contex.Response.WriteAsync(sb.ToString());
        }

        private async Task LibraryHandlerAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private async Task CatchHandlerAsync(HttpContext context)
        {
            var value = context.GetRouteValue("catchall")?.ToString();

            string msg ="";

            if (value == null)
                await context.Response.WriteAsync("Error input");

            var values = from valueroute in value.Split('/', StringSplitOptions.RemoveEmptyEntries) 
                              where int.TryParse(valueroute, out _) 
                              select valueroute;
            if (values.Count() == 0)
                await context.Response.WriteAsync("Error input");

            foreach (var item in values)
            {
                msg += $"\n{item}";
            }
            await context.Response.WriteAsync(msg);
        }

        private async Task BaseHandlerAsync(HttpContext context)
        {
            RouteValueDictionary values = context.GetRouteData().Values;

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, object> item in values)
            {
                sb.Append($"\nKEY: {item.Key} VALUE: {item.Value}");
            }
            
            await context.Response.WriteAsync(sb.ToString());
        }
        public Startup(IHostEnvironment env, IConfiguration appconfig)
        {
            _configuration = new ConfigurationBuilder()
                                    .AddJsonFile(Path.Combine(env.ContentRootPath, "configs", "accounts.json"), false, true)
                                    .AddJsonFile(Path.Combine(env.ContentRootPath, "configs", "books.json"), false, true)
                                    .AddConfiguration(appconfig)
                                    .Build();
        }    
    
    }
}
