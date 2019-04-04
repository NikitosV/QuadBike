using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        IUnitOfWork Database { get; set; }

        public ApplicationUserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
