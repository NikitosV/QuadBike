﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuadBike.Model.Context;
using QuadBike.Model.Context.Initializer;
using QuadBike.Model.Entities;

namespace QuadBike.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                Task t;
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<QuadBikeContext>();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<Account>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    t = Seed.Initialize(context, userManager, rolesManager);
                    t.Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
    }
}
