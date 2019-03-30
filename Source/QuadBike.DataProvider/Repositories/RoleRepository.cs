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
    public class RoleRepository : IRepository<Role>
    {
        private QuadBikeContext db;

        public RoleRepository(QuadBikeContext context)
        {
            this.db = context;
        }

        public void Create(Role item)
        {
            db.Roles.Add(item);
        }

        public void Delete(int id)
        {
            Role item = db.Roles.Find(id);
            if (item != null)
                db.Roles.Remove(item);
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return db.Roles.Where(predicate).ToList(); //LINQ
        }

        public Role Get(int id)
        {
            return db.Roles.Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Roles;
        }

        public void Update(Role item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
