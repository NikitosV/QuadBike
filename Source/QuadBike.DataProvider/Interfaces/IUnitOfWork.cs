using QuadBike.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        IBikeRepository bikeRepository { get; }
        IProviderRepository providerRepository { get; }
        IRentBikeRepository rentBikeRepository { get; }
        IRentTripRepository rentTripRepository { get; }
        ISimpleUserRepository simpleUserRepository { get; }
        ITripRepository tripRepository { get; }

        void Save();



        // Task SaveAsync();
    }
}
