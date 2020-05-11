using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace lesson3
{
    public class Startup
    {
        IConfiguration _configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfiguration>(provider=>_configuration);
            services.AddTransient<ITimer, Timer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration, ITimer timer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Person p = new Person();

            configuration.Bind(p);

            var company = (from item in configuration.GetChildren() where (int.TryParse(item.Value, out int x) && x > 100) orderby item.Value descending select item.Key).FirstOrDefault();

            app.Run(async context => await context.Response.WriteAsync((company ?? "company is not found") + "\n" + p.ToString() + "\n" + timer.GetPartOfDay()));
        }

        public Startup(IWebHostEnvironment env)
        {
            string path = env.ContentRootPath;
            _configuration = new ConfigurationBuilder()
                .AddIniFile(Path.Combine(path, "configurations", "inicfg.ini"))
                .AddJsonFile(Path.Combine(path, "configurations", "jsoncfg.json"))
                .AddJsonFile(Path.Combine(path, "configurations", "personality.json"))
                .AddXmlFile(Path.Combine(path, "configurations", "XMLcfg.xml"))
                .Build();
        }
    }
}
