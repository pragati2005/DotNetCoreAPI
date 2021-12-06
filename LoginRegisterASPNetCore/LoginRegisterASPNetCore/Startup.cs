using LoginRegisterASPNetCore.Data;
using LoginRegisterASPNetCore.Models;
using LoginRegisterASPNetCore.Repository;
//////using LoginRegisterASPNetCore.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SendEmail.Repository;
using System;
using System.ComponentModel;
using System.Text;

namespace LoginRegisterASPNetCore
{
    public class Startup
    {
       private readonly String ConnectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
       
            ConnectionString = Configuration.GetConnectionString("AuthenticationDB");
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
        .GetSection("EmailConfiguration")
        .Get<SendEmail.Models.EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<SendEmail.Repository.IEmailSender, SendEmail.Repository.EmailSender>();
            services.AddControllers();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<ITestItemsRepo, TestItemsRepo>();


            services.AddDbContext<DataDBContext>(Options => Options.UseSqlServer(ConnectionString));
            services.AddIdentity<Applicationuser, IdentityRole>().AddEntityFrameworkStores<DataDBContext>()
                .AddDefaultTokenProviders();
            //services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    //ValidAudience = Configuration["JWT:ValidAu"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qkfudwawbyclrslwhpfikzlahebtvcej"))
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SmartIt-secret-key"))

                };
                //services.AddAuthorization(options => options.AddPolicy("TwoFactorEnabled",
                //    x => x.RequireClaim("amr", "mfa")));
                

                services.AddControllers();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SendEmailNotificationDoNetCoreWebAPI", Version = "v1" });
                });
                services.AddCors(c =>
                {
                    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                });

            });

            
            
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoginRegisterASPNetCore", Version = "v1" });
            //});
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
});
                // To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter ‘Bearer’ [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
});
            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                  {
                 {
                           new OpenApiSecurityScheme
                                    {
                                    Reference = new OpenApiReference
                                    {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                    }
                                    },
                               new string[] {}
                 }
                  });
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoginRegisterASPNetCore v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
