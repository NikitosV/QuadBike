﻿using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class RentBikeRepository : IRepository<RentBike>, IRentBikeRepository
    {
        private QuadBikeContext db;

        public RentBikeRepository(QuadBikeContext context)
        {
            this.db = context;
        }

        public void Create(RentBike item)
        {
            db.RentBikes.Add(item);
        }

        public void Delete(int id)
        {
            RentBike item = db.RentBikes.Find(id);
            if (item != null)
                db.RentBikes.Remove(item);
        }

        public RentBike Get(int id)
        {
            return db.RentBikes.Find(id);
        }

        public IEnumerable<RentBike> GetAll()
        {
            return db.RentBikes;
        }

        public void Update(RentBike item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
