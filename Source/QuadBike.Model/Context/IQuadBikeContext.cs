using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Context
{
    public interface IQuadBikeContext : IDisposable
    {

        DbSet<Bike> Bikes { get; set; }

        DbSet<Trip> Trips { get; set; }

        DbSet<RentBike> RentBikes { get; set; }

        DbSet<RentTrip> RentTrips { get; set; }

        DbSet<Account> Accounts { get; set; }

        EntityEntry Entry(object item);

        int SaveChanges();
    }
}