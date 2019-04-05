using QuadBike.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Services
{
    public class BikeService : IBikeService
    {
        public string test()
        {
            return "if you see this. Its mean DI work :))";
        }
    }
}
