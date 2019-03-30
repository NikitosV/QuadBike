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
    public class AccountRepository : IRepository<Account>
    {
        private QuadBikeContext db;

        public AccountRepository(QuadBikeContext context)
        {
            this.db = context;
        }

        public void Create(Account item)
        {
            db.Accounts.Add(item);
        }

        public void Delete(int id)
        {
            Account item = db.Accounts.Find(id);
            if (item != null)
                db.Accounts.Remove(item);
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate)
        {
            return db.Accounts.Where(predicate).ToList();
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return db.Accounts;
        }

        public void Update(Account item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
