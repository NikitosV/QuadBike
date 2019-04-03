using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.EF;
using QuadBike.DataProvider.Entities;
using QuadBike.DataProvider.Identity;
using QuadBike.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.DataProvider.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        QuadBikeContext context;

        private BikeRepository _bikeRepository;
        private ProviderRepository _providerRepository;
        private RentBikeRepository _rentBikeRepository;
        private RentTripRepository _rentTripRepository;
        private TripRepository _tripRepository;
        private SimpleUserRepository _userRepository;

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;


        public EFUnitOfWork(DbContextOptions<QuadBikeContext> options)
        {
            context = new QuadBikeContext(options);

            //_userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //_roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
        }

        public IRepository<Bike> Bikes
        {
            get
            {
                if (_bikeRepository == null)
                    _bikeRepository = new BikeRepository(context);
                return _bikeRepository;
            }
        }

        public IRepository<Provider> Providers
        {
            get
            {
                if (_providerRepository == null)
                    _providerRepository = new ProviderRepository(context);
                return _providerRepository;
            }
        }

        public IRepository<RentBike> RentBikes
        {
            get
            {
                if (_rentBikeRepository == null)
                    _rentBikeRepository = new RentBikeRepository(context);
                return _rentBikeRepository;
            }
        }

        public IRepository<RentTrip> RentTrips
        {
            get
            {
                if (_rentTripRepository == null)
                    _rentTripRepository = new RentTripRepository(context);
                return _rentTripRepository;
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                if (_tripRepository == null)
                    _tripRepository = new TripRepository(context);
                return _tripRepository;
            }
        }
        

        public IRepository<SimpleUser> SimpleUsers
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new SimpleUserRepository(context);
                return _userRepository;
            }
        }

        #region !!!!!!!!!!!ATTENTION!!!!!!!!!!!!!!!
        public ApplicationUserManager UserManager => throw new NotImplementedException();

        public ApplicationRoleManager RoleManager => throw new NotImplementedException();

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
