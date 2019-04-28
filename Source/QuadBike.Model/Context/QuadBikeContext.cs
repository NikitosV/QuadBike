using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuadBike.Model.Context
{
    public class QuadBikeContext : IdentityDbContext<Account>, IQuadBikeContext
    {
        public QuadBikeContext(DbContextOptions<QuadBikeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<RentBike> RentBikes { get; set; }
        public DbSet<RentTrip> RentTrips { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }
}
