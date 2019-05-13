using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuadBike.Model.Context.Initializer
{
    public static class Seed
    {
        public static async Task Initialize(QuadBikeContext context, UserManager<Account> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            string moderEmail = "moder@moder.by";
            string userEmail = "user1@tut.by";
            string providerEmail = "provider1@tut.by";
            string providerEmailTwo = "provider2@tut.by";
            string password = "657F660n_";

            if (await _roleManager.FindByNameAsync("moderator") == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("moderator"));
            }
            if (await _roleManager.FindByNameAsync("user") == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await _roleManager.FindByNameAsync("provider") == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("provider"));
            }
            if (await _userManager.FindByNameAsync(moderEmail) == null)
            {
                Account moder = new Account { Email = moderEmail, UserName = moderEmail };
                IdentityResult result = await _userManager.CreateAsync(moder, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(moder, "moderator");
                }
            }
            if (await _userManager.FindByNameAsync(userEmail) == null)
            {
                Account user = new Account { Email = userEmail, UserName = userEmail };
                IdentityResult result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                }
            }
            if (await _userManager.FindByNameAsync(providerEmail) == null)
            {
                Account provider = new Account { Email = providerEmail, UserName = providerEmail };
                IdentityResult result = await _userManager.CreateAsync(provider, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(provider, "provider");
                }
            }
            if (await _userManager.FindByNameAsync(providerEmailTwo) == null)
            {
                Account provider = new Account { Email = providerEmailTwo, UserName = providerEmailTwo };
                IdentityResult result = await _userManager.CreateAsync(provider, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(provider, "provider");
                }
            }

            if (!context.Bikes.Any())
            {
                List<Bike> bikes = new List<Bike>();
                var us = _userManager.FindByNameAsync(providerEmail).Result;
                var us2 = _userManager.FindByNameAsync(providerEmailTwo).Result;

                string picturePath = "wwwroot/images_default/b1.jpg";
                FileStream fileStream = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes = new byte[fileStream.Length];
                fileStream.Read(PhotoBytes, 0, PhotoBytes.Length);

                string picturePath2 = "wwwroot/images_default/b2.jpg";
                FileStream fileStream2 = new FileStream(picturePath2, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes2 = new byte[fileStream2.Length];
                fileStream2.Read(PhotoBytes2, 0, PhotoBytes2.Length);

                bikes.Add(new Bike()
                {
                    Name = "Suzuki",
                    MaxSpeed = 20,
                    TypeEngine = "single",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV is the best off-road transport",
                    Price = 100,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes
                });
                bikes.Add(new Bike()
                {
                    Name = "Honda",
                    MaxSpeed = 20,
                    TypeEngine = "multiple",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV is the best off-road transport",
                    Price = 100,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes
                });
                bikes.Add(new Bike()
                {
                    Name = "Honda",
                    MaxSpeed = 20,
                    TypeEngine = "single",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV is the best off-road transport",
                    Price = 100,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes
                });
                //=================================2================
                bikes.Add(new Bike()
                {
                    Name = "Suzuki",
                    MaxSpeed = 20,
                    TypeEngine = "single",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV is the best off-road transport",
                    Price = 100,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes2
                });
                bikes.Add(new Bike()
                {
                    Name = "Honda",
                    MaxSpeed = 20,
                    TypeEngine = "multiple",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV is the best off-road transport",
                    Price = 100,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes2
                });
                bikes.Add(new Bike()
                {
                    Name = "Honda",
                    MaxSpeed = 20,
                    TypeEngine = "single",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV is the best off-road transport",
                    Price = 100,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes2
                });

                context.AddRange(bikes);
                context.SaveChanges();
            }

            if (!context.Trips.Any())
            {
                List<Trip> trips = new List<Trip>();
                var us = _userManager.FindByNameAsync(providerEmail).Result;
                var us2 = _userManager.FindByNameAsync(providerEmailTwo).Result;

                string picturePath = "wwwroot/images_default/t1.jpg";
                FileStream fileStream = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes = new byte[fileStream.Length];
                fileStream.Read(PhotoBytes, 0, PhotoBytes.Length);

                string picturePath2 = "wwwroot/images_default/t2.jpg";
                FileStream fileStream2 = new FileStream(picturePath2, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes2 = new byte[fileStream2.Length];
                fileStream2.Read(PhotoBytes2, 0, PhotoBytes2.Length);

                trips.Add(new Trip()
                {
                    TripName = "Forest",
                    Type = "forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "DTFGYHUJIHGFCDFCGVHUJIHGVFCDXFCGVHJUYGTFRDTFYGHUJ",
                    Price = 200,
                    TripImg = PhotoBytes,
                    AccountId = us.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Forest",
                    Type = "forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "DTFGYHUJIHGFCDFCGVHUJIHGVFCDXFCGVHJUYGTFRDTFYGHUJ",
                    Price = 200,
                    TripImg = PhotoBytes,
                    AccountId = us.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Forest",
                    Type = "forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "DTFGYHUJIHGFCDFCGVHUJIHGVFCDXFCGVHJUYGTFRDTFYGHUJ",
                    Price = 200,
                    TripImg = PhotoBytes,
                    AccountId = us.Id
                });

                //=========================================2==============
                trips.Add(new Trip()
                {
                    TripName = "Mountain",
                    Type = "forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "DTFGYHUJIHGFCDFCGVHUJIHGVFCDXFCGVHJUYGTFRDTFYGHUJ",
                    Price = 200,
                    TripImg = PhotoBytes2,
                    AccountId = us2.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Mountain",
                    Type = "forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "DTFGYHUJIHGFCDFCGVHUJIHGVFCDXFCGVHJUYGTFRDTFYGHUJ",
                    Price = 200,
                    TripImg = PhotoBytes2,
                    AccountId = us2.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Mountain",
                    Type = "forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "DTFGYHUJIHGFCDFCGVHUJIHGVFCDXFCGVHJUYGTFRDTFYGHUJ",
                    Price = 200,
                    TripImg = PhotoBytes2,
                    AccountId = us2.Id
                });

                context.AddRange(trips);
                context.SaveChanges();
            }
        }
    }
}
