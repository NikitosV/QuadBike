using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.EF
{
    public class QuadBikeContext : IdentityDbContext<ApplicationUser>
    {
        public QuadBikeContext(DbContextOptions<QuadBikeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SimpleUser> SimpleUsers { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<RentBike> RentBikes { get; set; }

        public DbSet<RentTrip> RentTrips { get; set; }
    }
}
