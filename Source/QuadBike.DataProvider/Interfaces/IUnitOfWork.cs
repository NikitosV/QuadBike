using QuadBike.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Account> Accounts { get; }
        IRepository<Bike> Bikes { get; }
        IRepository<Provider> Providers { get; }
        IRepository<RentBike> RentBikes { get; }
        IRepository<RentTrip> RentTrips { get; }
        IRepository<Role> Roles { get; }
        IRepository<Trip> Trips { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
