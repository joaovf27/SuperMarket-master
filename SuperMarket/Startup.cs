using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Impl;
using BLL.Interfaces;
using DAL;
using DAL.Impl;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SuperMarket
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
            //services.AddTransient<//interface>
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProviderService, ProviderService>();
            services.AddTransient<IProviderRepository, ProviderRepository>();
            services.AddTransient<DbOptionsADO, DbOptionsADO>();


            services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

           
            
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.LogoutPath = "/User/LogOff";
                options.Cookie.Name = "AshProgHelpCookie";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
