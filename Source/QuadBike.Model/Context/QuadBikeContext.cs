using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuadBike.Model.Context
{
    public class QuadBikeContext : IdentityDbContext<Account>, IQuadBikeContext
    {
        public QuadBikeContext(DbContextOptions<QuadBikeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}