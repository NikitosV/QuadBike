using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuadBike.Model.ViewModel.BikeViewModels;
using QuadBike.Model.ViewModel.Pagination;

namespace QuadBike.DataProvider.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private IQuadBikeContext _db;

        public BikeRepository(IQuadBikeContext context)
        {
            this._db = context;
        }

        public void Create(Bike item)                            //create
        {
            _db.Bikes.Add(item);
        }

        public void Delete(int id)                                  //delete
        {
            Bike item = _db.Bikes.Find(id);
            if (item != null)
                _db.Bikes.Remove(item);
        }

        public Bike Get(int id)                                    // read
        {
            return _db.Bikes.Find(id);
        }

        public IEnumerable<Bike> GetAll()                             // read all
        {
            return _db.Bikes;
            //Include(x => x.Name)
        }

        public void Update(Bike item)                               // update
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void DeleteById(int? bikeId)
        {
            Bike bike = _db.Bikes.Find(bikeId);
            if (bike != null)
            {
                _db.Bikes.Remove(bike);
            }
        }

        public IEnumerable<Bike> GetBikesOfCurrentProvider(string id)
        {
            var res = _db.Bikes.Where(x => x.AccountId.Equals(id));
            return res;
        }

        public IEnumerable<IndexBikeViewModel> GetBikesWithProviderInfo()
        {
            var res = (from bike in _db.Bikes
                join provider in _db.Accounts on bike.AccountId equals provider.Id
                select new IndexBikeViewModel()
                {
                    Id = bike.Id,
                    BikeImg = bike.BikeImg,
                    Name = bike.Name,
                    MaxSpeed = bike.MaxSpeed,
                    TypeEngine = bike.TypeEngine,
                    Power = bike.Power,
                    Fuel = bike.Fuel,
                    Description = bike.Description,
                    Price = bike.Price,
                    AccountId = bike.AccountId,
                    Email = provider.Email

                }).ToList();
            return res;
        }
    }
}