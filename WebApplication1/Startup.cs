using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Interfaces.Helper;
using WebApplication1.Interfaces.ServiceInterface;
using WebApplication1.Middleware;
using WebApplication1.Model;
using WebApplication1.Services;
using WebApplication1.Settings;

namespace WebApplication1
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
           
        }
       


        public IConfiguration Configuration { get; }
        public GitHubSetting GitHubSettings { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            /*
                        services
             .AddAuthentication(opt =>
             {
                 opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                 opt.DefaultChallengeScheme = "GitHub";
             })
             .AddCookie()
             .AddGitHub("GitHub", opt =>
             {
                 opt.ClientId = "da5ed15d1a9104873010";
                 opt.ClientSecret = "e440197bc6d677f932484813448fb92261ef79cd";
                 opt.CallbackPath = new PathString("/signin-github");
                 opt.SaveTokens = true;


             });*/


            /*
                        services.AddSwaggerGen(c =>
                        {


                            c.AddSecurityDefinition("GitHub", new OAuth2Scheme
                            {
                                Type = "oauth2",
                                Flow = "accessCode",
                                AuthorizationUrl = "https://github.com/login/oauth/authorize",
                                TokenUrl = "https://github.com/login/oauth/access_token"
                            });

                            c.OperationFilter<SecurityRequirementsOperationFilter>();
                        });


            */

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    Description = "GitHub Authentication"
                });
                c.ParameterFilter<TypeParameterFilter>();

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                      {
                                  {
                                  new OpenApiSecurityScheme
                                  {
                                      Reference=new OpenApiReference
                                      {
                                          Type=ReferenceType.SecurityScheme,
                                          Id="Bearer"
                                      }

                                 },
                                  new string[]{}
                                  }
                       });
            });
            services.AddAuthentication("GitHubAuthentication").AddScheme<AuthenticationSchemeOptions,GitHubAuthentication>("GitHubAuthentication", null);
            services.AddTransient<IRMZInterface, RMZService>();
            services.AddDbContextPool<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwaggerUI(opt =>
            {
                opt.DisplayRequestDuration();
                opt.RoutePrefix = string.Empty;
                opt.SwaggerEndpoint("swagger/v1/swagger.json", "Playground API V1");
                opt.OAuth2RedirectUrl("https://github.com/login/oauth/authorize");
                opt.OAuthClientId("da5ed15d1a9104873010");
                opt.OAuthClientSecret("e440197bc6d677f932484813448fb92261ef79cd");
                opt.OAuthAppName("dotNet Core Playground");
            });
        

            app.UseAuthentication();

            app.UseAuthorization();

         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
