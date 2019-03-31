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
    public class UserRepository : IRepository<SimpleUser>
    {
        private QuadBikeContext db;

        public UserRepository(QuadBikeContext context)
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

        public IEnumerable<SimpleUser> Find(Func<SimpleUser, bool> predicate)
        {
            return db.SimpleUsers.Where(predicate).ToList();
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
