using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, string accId, string userName);
    }
}
