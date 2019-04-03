using QuadBike.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Interfaces
{
    public interface IBikeService
    {
        void AddName(int bikeId, string name);
        void AddSpeed(int bikeId, string speed);
        void AddTypeEngine(int bikeId, string typeEngine);
        void AddPower(int bikeId, string power);
        void AddFuel (int bikeId, string fuel);
        void AddDescription (int bikeId, string fuel);
        void AddPrice (int bikeId, string fuel);
    }
}