using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace lesson1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ResponseQuery
    {
        private readonly RequestDelegate _next;

        public ResponseQuery(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            StringBuilder sb = new StringBuilder();

            Random rnd = new Random();

            foreach (var item in httpContext.Request.Query)
            {
                sb.Append($"KEY: {item.Key} VALUE: {item.Value}");
            }

            Company company = new Company("TopProm", "Russia", 3244);

            await httpContext.Response.WriteAsync($"PATH: {httpContext.Request.Path.Value} \n rundom number = {rnd.Next(1, 1000)} \n " +
                company.ToString() + "\n" + sb.ToString());
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseResponseQuery(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseQuery>();
        }
    }
}
