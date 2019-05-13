using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Context
{
    public interface IQuadBikeContext : IDisposable
    {

        DbSet<Bike> Bikes { get; set; }

        DbSet<Trip> Trips { get; set; }
        
        DbSet<Account> Accounts { get; set; }

        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderDetail> OrderDetails { get; set; }

        EntityEntry Entry(object item);

        int SaveChanges();
    }
}