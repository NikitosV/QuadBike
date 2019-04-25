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
    public class BikeRepository : IBikeRepository
    {
        private IQuadBikeContext db;

        public BikeRepository(IQuadBikeContext context)
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

        public void DeleteById(int? bikeId)
        {
            Bike bike = db.Bikes.Find(bikeId);
            if (bike != null)
            {
                db.Bikes.Remove(bike);
            }
        }

        public IEnumerable<Bike> GetBikesOfCurrentProvider(string id)
        {
            var res = db.Bikes.Where(x => x.AccountId.Equals(id));
            return res;
        }
    }
}
