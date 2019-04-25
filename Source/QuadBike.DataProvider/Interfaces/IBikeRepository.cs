using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IBikeRepository : IRepository<Bike>
    {
        void DeleteById(int? id);
        IEnumerable<Bike> GetBikesOfCurrentProvider(string id);
    }
}
