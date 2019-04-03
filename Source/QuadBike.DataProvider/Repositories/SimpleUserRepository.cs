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
    public class SimpleUserRepository : IRepository<SimpleUser>, ISimpleUserRepository
    {
        private QuadBikeContext db;

        public SimpleUserRepository(QuadBikeContext context)
        {
            this.db = context;
        }
        public void Create(SimpleUser item)
        {
            db.SimpleUsers.Add(item);
        }

        public void Delete(int id)
        {
            SimpleUser item = db.SimpleUsers.Find(id);
            if (item != null)
                db.SimpleUsers.Remove(item);
        }

        public SimpleUser Get(int id)
        {
            return db.SimpleUsers.Find(id);
        }

        public IEnumerable<SimpleUser> GetAll()
        {
            return db.SimpleUsers;
        }

        public void Update(SimpleUser item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
