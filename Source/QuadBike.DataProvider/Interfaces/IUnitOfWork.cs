using QuadBike.DataProvider.Entities;
using QuadBike.DataProvider.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        IRepository<Bike> Bikes { get; }
        IRepository<Provider> Providers { get; }
        IRepository<RentBike> RentBikes { get; }
        IRepository<RentTrip> RentTrips { get; }
        IRepository<Trip> Trips { get; }
        IRepository<SimpleUser> SimpleUsers { get; }
        void Save();
        Task SaveAsync();
    }
}
