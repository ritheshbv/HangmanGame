using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SbsApplication.Models;
using SbsApplication.Services;
using SbsApplication.Services.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApplication
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
            services.AddControllersWithViews();
            services.AddSingleton<ILoginViewModel, LoginViewModel>();
            services.AddSingleton<IUserViewModel, UserViewModel>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<ILoginApiService, LoginApiService>();
            services.AddSingleton<IRegistrationService, RegistrationService>();
            services.AddSingleton<IHangmanApiService, HangmanApiService>();
            services.AddSingleton<IHangmanWordModel, HangmanWordModel>();
            services.AddSingleton<IHangmanService, HangmanService>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
