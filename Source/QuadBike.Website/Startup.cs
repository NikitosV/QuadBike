using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Extensions.FileProviders;
using QuadBike.DataProvider.Interfaces;
using QuadBike.DataProvider.Repositories;
using QuadBike.Logic.Interfaces;
using QuadBike.Logic.Services;
using QuadBike.Model.Context;
using QuadBike.Model.Context.CommitProvider;
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
            services.AddScoped<IQuadBikeContext, QuadBikeContext>();

            services.AddDbContext<QuadBikeContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Account, IdentityRole>()           // Attention
                .AddEntityFrameworkStores<QuadBikeContext>();

            services.AddScoped<ICommitProvider, CommitProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Errors");
                app.UseStatusCodePagesWithReExecute("/Errors/Error/{0}");
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "node_modules")
                ),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
