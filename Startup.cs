using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBS_DALayer.Models;
using IBS_RSLayer;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using IBS_UILayer.BAServices;

namespace IBS_UILayer
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient(typeof(AccountCreationService));

            services.AddDbContext<InternetBankingSystemContext>();
            //to Configure identity database
            //services.AddDbContext<myDbContext>(c =>
            //{
            //    c.UseSqlServer(Configuration.GetConnectionString("Connection"));
            //});

            //services.AddIdentity<myUser, IdentityRole>(
            //c =>
            //{
            //    c.Password.RequiredLength = 4;
            //    c.Password.RequireDigit = false;
            //    c.Password.RequireUppercase = false;
            //    c.Password.RequireNonAlphanumeric = false;

            //}).AddEntityFrameworkStores<myDbContext>().AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(c =>
            //{
            //    c.LoginPath = "/AccountCreation/Login";
            //    c.Cookie.Name = "IdentityCookie";
            //    c.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            //});


            services.AddMvc();
            services.AddTransient(typeof(InternetBankingSystemContext));
            services.AddTransient(typeof(ICustomerDb<>), typeof(ImpCustomer<>));

            //to configure swagger

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v2", new OpenApiInfo
                    {
                        Title = "IBS",
                        Version = "v2"  
                    });
                    c.ResolveConflictingActions(p => p.First());
                });

            // swagger configeration ends

            // Normal cookie authentication

            services.AddAuthentication("Guard")
                .AddCookie("Guard", c =>
                {
                    c.LoginPath = "/AccountCreation/Login";
                    c.Cookie.Name = "GuardCookie";
                });



            services.AddSession(c =>
            {
                c.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/ErrorPage");
                app.UseStatusCodePagesWithReExecute("/ErrorPage/{0}");
            }
            

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v2/swagger.json", "InternetBankingSystem");
            });

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=MainMenu}/{action=Home}/{id?}");
            });
        }
    } 
}