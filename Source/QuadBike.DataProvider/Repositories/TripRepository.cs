using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.EF;
using QuadBike.DataProvider.Entities;
using QuadBike.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class TripRepository : IRepository<Trip>, ITripRepository
    {
        private QuadBikeContext db;

        public TripRepository(QuadBikeContext context)
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
    }
}
