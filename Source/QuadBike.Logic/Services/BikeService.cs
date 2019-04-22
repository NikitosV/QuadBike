using Microsoft.AspNetCore.Identity;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Context.CommitProvider;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.BikeViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.Logic.Services
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly ICommitProvider _commitProvider;
        private readonly IUserManagerService _userManagerService;

        public BikeService(IBikeRepository bikeRepository, ICommitProvider commitProvider, IUserManagerService userManagerService)
        {
            _bikeRepository = bikeRepository;
            _commitProvider = commitProvider;
            _userManagerService = userManagerService;
        }

        public void CreateBike(BikeViewModel model, string userId)
        {
            var res = _userManagerService.GetUserById(userId);
            _bikeRepository.Create(new Bike
            {
                Name = model.Name,
                MaxSpeed = model.MaxSpeed,
                TypeEngine = model.TypeEngine,
                Power = model.Power,
                Fuel = model.Fuel,
                Description = model.Description,
                AccountId = res.Result.Id,
                Price = model.Price
            });
            _commitProvider.Save();
        }

        public IEnumerable<Bike> GetAllBikes()                             // read all
        {
            return _bikeRepository.GetAll();
        }

        public void DeleteById(int? id)                                 // get by id
        {
            _bikeRepository.DeleteById(id);
        }

    }
}

//public int Id { get; set; }           //Id