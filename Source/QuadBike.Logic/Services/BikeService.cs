using QuadBike.DataProvider.Entities;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.DTO;
using QuadBike.Logic.Interfaces;
using QuadBike.Logic.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Services
{
    public class BikeService : IBikeService
    {
        private readonly IUnitOfWork Database;
        Map<Bike, BikeDTO> Map = new Map<Bike, BikeDTO>();
    }
}
