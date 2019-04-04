using Microsoft.EntityFrameworkCore;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Context
{
    public interface IQuadBikeContext : IDisposable
    {
        DbSet<MyUser> MyUsers { get; set; }

        DbSet<Provider> Providers { get; set; }

        DbSet<Bike> Bikes { get; set; }

        DbSet<Trip> Trips { get; set; }

        DbSet<RentBike> RentBikes { get; set; }

        DbSet<RentTrip> RentTrips { get; set; }

        int SaveChanges();
    }
}