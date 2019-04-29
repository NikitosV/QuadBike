using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context.CommitProvider;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.TripViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly ICommitProvider _commitProvider;
        private readonly IUserManagerService _userManagerService;

        public TripService(ITripRepository tripRepository, ICommitProvider commitProvider, IUserManagerService userManagerService)
        {
            _tripRepository = tripRepository;
            _commitProvider = commitProvider;
            _userManagerService = userManagerService;
        }

        public void CreateTrip(TripViewModel model, string userId, byte[] imageData)
        {
            var res = _userManagerService.GetUserById(userId);
            _tripRepository.Create(new Trip
            {
                TripName = model.TripName,
                Type = model.Type,
                Distance = model.Distance,
                AmountOfPeople = model.AmountOfPeople,
                StartDate = model.StartDate,
                EndTrip = model.EndTrip,
                Description = model.Description,
                AccountId = res.Result.Id,
                Price = model.Price,
                TripImg = imageData
            });
            _commitProvider.Save();
        }

        public void DeleteById(int? id)                                 // get by id
        {
            _tripRepository.DeleteById(id);
        }

        public IEnumerable<Trip> GetTripsOfCurrentProvider(string id)
        {
            var res = _tripRepository.GetTripsOfCurrentProvider(id);
            return res;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _tripRepository.GetAll();
        }

        public Trip GetTripById(int id)
        {
            var res = _tripRepository.Get(id);
            return res;
        }

        public bool Update(Trip item)
        {
            if (item != null)
            {
                _tripRepository.Update(item);
                return true;
            }
            return false;
        }
    }
}
