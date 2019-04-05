using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private QuadBikeContext db;

        public BikeRepository(QuadBikeContext context)
        {
            this.db = context;
        }

        public void Create(Bike item)                            //create
        {
            db.Bikes.Add(item);
        }

        public void Delete(int id)                                  //delete
        {
            Bike item = db.Bikes.Find(id);
            if (item != null)
                db.Bikes.Remove(item);
        }

        public Bike Get(int id)                                    // read
        {
            return db.Bikes.Find(id);
        }

        public IEnumerable<Bike> GetAll()                             // read all
        {
            return db.Bikes;
        }

        public void Update(Bike item)                               // update
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
