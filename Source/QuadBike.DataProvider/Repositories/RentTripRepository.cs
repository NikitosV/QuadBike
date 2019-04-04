using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class RentTripRepository : IRepository<RentTrip>, IRentTripRepository
    {
        private QuadBikeContext db;

        public RentTripRepository(QuadBikeContext context)
        {
            this.db = context;
        }

        public void Create(RentTrip item)
        {
            db.RentTrips.Add(item);
        }

        public void Delete(int id)
        {
            RentTrip item = db.RentTrips.Find(id);
            if (item != null)
                db.RentTrips.Remove(item);
        }

        public RentTrip Get(int id)
        {
            return db.RentTrips.Find(id);
        }

        public IEnumerable<RentTrip> GetAll()
        {
            return db.RentTrips;
        }

        public void Update(RentTrip item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
