using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netcorewebapi.Models;
using Netcorewebapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcorewebapi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddSingleton<IEmployeeRepo,EmployeeRepo>();
            service.AddTransient<CustomMiddleware>();
           
            //service.AddTransient<Employee>();
            //service.AddTransient<ConstraintsDemo>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello this is from first Use method" + "\n");
            //    await next();
            //    await context.Response.WriteAsync("This is also within Use method" + "\n");
            //});


            //app.Run(async context => await context.Response.WriteAsync("Helvlo , this is run method of middleware stopping further middleware execution"+"\n"));

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello this is from second Use method" + "\n");
            //    await next();
            //    //await context.Response.WriteAsync("This is also within second Use method" + "\n");
            //});
            //app.UseMiddleware<CustomMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello this is from Use method after middleware" + "\n");
                await next();
                //await context.Response.WriteAsync("This is also within second Use method" + "\n");
            });

            


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //       await context.Response.WriteAsync("Hello Welcome to custom web api project");
            //    });
            //    endpoints.MapGet("/test/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Welcome to custom web api project !! Testing !!!");
            //    });
            //    endpoints.MapGet("/test/double/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Welcome to custom web api project !! Testing double !!!");
            //    });
            //}
            //);  

        }

        private void CustomBehavior(IApplicationBuilder app, IWebHostEnvironment env)
        {
            



        }
    }
}
