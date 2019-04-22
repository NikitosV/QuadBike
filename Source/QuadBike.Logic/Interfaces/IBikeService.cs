using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.BikeViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Interfaces
{
    public interface IBikeService
    {
        void CreateBike(BikeViewModel model, string userId);
        IEnumerable<Bike> GetAllBikes();
        void DeleteById(int? id);
    }
}
