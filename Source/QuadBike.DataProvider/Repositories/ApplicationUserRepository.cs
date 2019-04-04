using QuadBike.DataProvider.EF;
using QuadBike.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private QuadBikeContext db;

        public ApplicationUserRepository(QuadBikeContext context)
        {
            this.db = context;
        }
    }
}
