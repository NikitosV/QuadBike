using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Context
{
    public class QuadBikeContext : IdentityDbContext<Account>, IQuadBikeContext
    {
        QuadBikeContext context;

        public QuadBikeContext(DbContextOptions<QuadBikeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Provider> Providers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Bike> Bikes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Trip> Trips { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<RentBike> RentBikes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<RentTrip> RentTrips { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<MyUser> MyUsers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
