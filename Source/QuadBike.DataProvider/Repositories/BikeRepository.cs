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
    public class BikeRepository : IRepository<Bike>, IBikeRepository
    {
        private QuadBikeContext db;

        public BikeRepository(QuadBikeContext context)
        {
            this.db = context;
        }

        public void Create(Bike item)
        {
            db.Bikes.Add(item);
        }

        public void Delete(int id)
        {
            Bike item = db.Bikes.Find(id);
            if (item != null)
                db.Bikes.Remove(item);
        }

        public Bike Get(int id)
        {
            return db.Bikes.Find(id);
        }

        public IEnumerable<Bike> GetAll()
        {
            return db.Bikes;
        }

        public void Update(Bike item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
