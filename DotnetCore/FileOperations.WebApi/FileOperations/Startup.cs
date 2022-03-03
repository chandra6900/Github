using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileOperations.Common;
using Microsoft.IdentityModel.Tokens;
using FileOperations.Services;

namespace FileOperations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            bool isAuthenticationEnabled = Configuration.GetValue<bool>("AppSettings:IsAuthenticationEnab1ed");
            if (isAuthenticationEnabled)
            {
                TokenManagement token;
                Utilities.Configuration = Configuration;
                services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
                token = Configuration.GetSection("TokenManagement").Get<TokenManagement>();

                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RefreshOnIssuerKeyNotFound = true;
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKeyResolver = Utilities.JWKSIssuerSigningKeyResolver,
                        ValidIssuer = token.Issuer,
                        ValidAudience = token.Audience,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true
                    };
                });
            }

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Logger>>();
            services.AddSingleton(typeof(ILogger), logger);
            services.AddSingleton<IFileOperation, FileOperation>();
            
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "File Operations API",
                        Description = "API Documentation for File Operations API",
                        Version = "v1"
                    });
                var jwtSecuritySceheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    Description = @"JWT Authorization header using the Bearer scheme. Enter JWT Bearer token in the text input below.",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition(jwtSecuritySceheme.Reference.Id, jwtSecuritySceheme);
                options.AddSecurityRequirement(
                    new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {jwtSecuritySceheme, Array.Empty<string>()}
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            string basePath = Configuration.GetValue<string>("AppSettings:BasePath");
            app.UsePathBase(basePath);
            app.UseHttpsRedirection();

            app.UseRouting();
            bool isAuthenticationEnabled = Configuration.GetValue<bool>("AppSettings:IsAuthenticationEnabled");
            if(isAuthenticationEnabled)
            {
                app.UseAuthentication();
                app.UseAuthentication();

                app.UseEndpoints(endpoints =>
                {
                    endpoints
                        .MapControllers()
                        .RequireAuthorization();
                });
            }
            else
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                string swaggerEndpoint = basePath + "/swagger/v1/swagger.json";
                options.SwaggerEndpoint(swaggerEndpoint, "File Operations API");
            });
        }
    }
}
