using QuadBike.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Bike> Bikes { get; }
        IRepository<Provider> Providers { get; }
        IRepository<RentBike> RentBikes { get; }
        IRepository<RentTrip> RentTrips { get; }
        IRepository<Trip> Trips { get; }
        IRepository<SimpleUser> SimpleUsers { get; }
        void Save();
    }
}
