using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private QuadBikeContext db;

        public ProviderRepository(QuadBikeContext context)
        {
            this.db = context;
        }

        public void Create(Provider item)
        {
            db.Providers.Add(item);
        }

        public void Delete(int id)
        {
            Provider item = db.Providers.Find(id);
            if (item != null)
                db.Providers.Remove(item);
        }

        public Provider Get(int id)
        {
            return db.Providers.Find(id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return db.Providers;
        }

        public void Update(Provider item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
