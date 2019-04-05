using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuadBike.DataProvider.Interfaces;
using QuadBike.DataProvider.Repositories;
using QuadBike.Logic.Interfaces;
using QuadBike.Logic.Services;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;

namespace QuadBike.Website
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
            services.AddDbContext<IQuadBikeContext, QuadBikeContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Account, IdentityRole>()           // Attention
                .AddEntityFrameworkStores<QuadBikeContext>();

            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<IMyUserRepository, MyUserRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IRentBikeRepository, RentBikeRepository>();
            services.AddScoped<IRentTripRepository, RentTripRepository>();
            services.AddScoped<ITripRepository, TripRepository>();

            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<IMyUserService, MyUserService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IRentBikeService, RentBikeService>();
            services.AddScoped<IRentTripService, RentTripService>();
            services.AddScoped<ITripService, TripService>();

            services.AddScoped<IUserManagerService, UserManagerService>();

            services.AddMvc();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
