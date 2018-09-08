using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace berg8.api
{

    public struct Setting
    {
        public const string policyOriginName = "AllowBerg8WebAccessOrigin";
        public const string strOriginApiDomain = @"http://localhost:3000";
        public const string strOriginApiDomainSameOrigin = @"https://0.0.0.0:80";
    }
    public struct ApiSymmetric
    {
        public const string PrivateKey = @"qazxswedcfgbbnjmnjkljhnmnbhjklijkmnkjhbbvfghgfgvbnkjkl";
    }
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
            // configure strongly typed settings objects
            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt => 
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer = "localhost://5001",
                    ValidAudience = "localhost://5001",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiSymmetric.PrivateKey)),
                    //IssuerSigningKey = new X509SecurityKey() //for certificate file
                };
            });
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddFacebook(opt => 
            //{
            //    
            //})
            //services.AddDbContext<Berg8Context>(opt => opt.UseSqlServer(
            //    Configuration.GetConnectionString("defaultConnectionString")
            //));

            services.AddCors(options => options.AddPolicy(Setting.policyOriginName, builder =>
            {
                builder.AllowAnyOrigin()
                       //.WithOrigins(Setting.strOriginApiDomain)
                       .AllowCredentials()
                       .AllowAnyMethod()
                       //.WithHeaders("accept", "content-type", "origin", "x-custom-header")
                       .AllowAnyHeader()
                       ;
                })
            );
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(Setting.policyOriginName));
            });
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()) //response fact in declare, not like camal case
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseCors("all");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class Berg8Context
    {
        
    }
}
