using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.TripViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Interfaces
{
    public interface ITripService
    {
        IEnumerable<Trip> GetTripsOfCurrentProvider(string id);
        void CreateTrip(TripViewModel model, string userId);
        void DeleteById(int? id);
    }
}
