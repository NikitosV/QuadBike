using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class TripRepository : ITripRepository
    {
        private IQuadBikeContext db;

        public TripRepository(IQuadBikeContext context)
        {
            this.db = context;
        }
        public void Create(Trip item)
        {
            db.Trips.Add(item);
        }

        public void Delete(int id)
        {
            Trip item = db.Trips.Find(id);
            if (item != null)
                db.Trips.Remove(item);
        }

        public Trip Get(int id)
        {
            return db.Trips.Find(id);
        }

        public IEnumerable<Trip> GetAll()
        {
            return db.Trips;
        }

        public void Update(Trip item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void DeleteById(int? tripId)
        {
            Trip trip = db.Trips.Find(tripId);
            if (trip != null)
            {
                db.Trips.Remove(trip);
            }
        }

        public IEnumerable<Trip> GetTripsOfCurrentProvider(string id)
        {
            var res = db.Trips.Where(x => x.AccountId.Equals(id));
            return res;
        }
    }
}
