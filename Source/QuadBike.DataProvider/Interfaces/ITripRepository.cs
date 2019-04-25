using QuadBike.DataProvider.Repositories;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Interfaces
{
    public interface ITripRepository : IRepository<Trip>
    {
        IEnumerable<Trip> GetTripsOfCurrentProvider(string id);
        void DeleteById(int? tripId);
    }
}
