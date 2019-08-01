using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.BikeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadBike.Logic.Interfaces
{
    public interface IBikeService
    {
        void CreateBike(BikeViewModel model, string userId, byte[] imageData);
        IEnumerable<Bike> GetAllBikes();
        void DeleteById(int? id);
        IEnumerable<Bike> GetBikesOfCurrentProvider(string id);
        Bike GetBikeById(int id);
        bool Update(Bike item);
        IEnumerable<IndexBikeViewModel> GetBikesWithProviderInfo();

        IQueryable<PaginationBikeViewModel> PaginationBikes(int pageSize, int currentPage);
        int CountBikes();
    }
}
