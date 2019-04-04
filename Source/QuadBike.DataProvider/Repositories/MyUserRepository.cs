using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class MyUserRepository : IRepository<MyUser>, IMyUserRepository
    {
        private QuadBikeContext db;

        public MyUserRepository(QuadBikeContext context)
        {
            this.db = context;
        }
        public void Create(MyUser item)
        {
            db.MyUsers.Add(item);
        }

        public void Delete(int id)
        {
            MyUser item = db.MyUsers.Find(id);
            if (item != null)
                db.MyUsers.Remove(item);
        }

        public MyUser Get(int id)
        {
            return db.MyUsers.Find(id);
        }

        public IEnumerable<MyUser> GetAll()
        {
            return db.MyUsers;
        }

        public void Update(MyUser item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
