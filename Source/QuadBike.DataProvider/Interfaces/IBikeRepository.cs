using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.BikeViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IBikeRepository : IRepository<Bike>
    {
        void DeleteById(int? id);
        IEnumerable<Bike> GetBikesOfCurrentProvider(string id);
        IEnumerable<IndexBikeViewModel> GetBikesWithProviderInfo();
    }
}
