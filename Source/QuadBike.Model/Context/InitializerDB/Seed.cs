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

                #region upload photos
                string picturePath = "wwwroot/images_default/b1.jpg";
                FileStream fileStream = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes = new byte[fileStream.Length];
                fileStream.Read(PhotoBytes, 0, PhotoBytes.Length);
                fileStream.Close();

                string picturePath2 = "wwwroot/images_default/b2.jpg";
                FileStream fileStream2 = new FileStream(picturePath2, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes2 = new byte[fileStream2.Length];
                fileStream2.Read(PhotoBytes2, 0, PhotoBytes2.Length);
                fileStream2.Close();

                string picturePath3 = "wwwroot/images_default/b3.jpg";
                FileStream fileStream3 = new FileStream(picturePath3, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes3 = new byte[fileStream3.Length];
                fileStream3.Read(PhotoBytes3, 0, PhotoBytes3.Length);
                fileStream3.Close();

                string picturePath4 = "wwwroot/images_default/b4.jpg";
                FileStream fileStream4 = new FileStream(picturePath4, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes4 = new byte[fileStream4.Length];
                fileStream4.Read(PhotoBytes4, 0, PhotoBytes4.Length);
                fileStream4.Close();

                string picturePath5 = "wwwroot/images_default/b5.jpg";
                FileStream fileStream5 = new FileStream(picturePath5, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes5 = new byte[fileStream5.Length];
                fileStream5.Read(PhotoBytes5, 0, PhotoBytes5.Length);
                fileStream5.Close();

                string picturePath6 = "wwwroot/images_default/b6.jpg";
                FileStream fileStream6 = new FileStream(picturePath6, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes6 = new byte[fileStream6.Length];
                fileStream6.Read(PhotoBytes6, 0, PhotoBytes6.Length);
                fileStream6.Close();

                string picturePath7 = "wwwroot/images_default/b7.jpg";
                FileStream fileStream7 = new FileStream(picturePath7, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes7 = new byte[fileStream7.Length];
                fileStream7.Read(PhotoBytes7, 0, PhotoBytes7.Length);
                fileStream7.Close();

                string picturePath8 = "wwwroot/images_default/b8.jpg";
                FileStream fileStream8 = new FileStream(picturePath8, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes8 = new byte[fileStream8.Length];
                fileStream8.Read(PhotoBytes8, 0, PhotoBytes8.Length);
                fileStream8.Close();

                string picturePath9 = "wwwroot/images_default/b9.jpg";
                FileStream fileStream9 = new FileStream(picturePath9, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes9 = new byte[fileStream9.Length];
                fileStream9.Read(PhotoBytes9, 0, PhotoBytes9.Length);
                fileStream9.Close();
                #endregion

                bikes.Add(new Bike()
                {
                    Name = "Stels ATV 300B",
                    MaxSpeed = 120, //km/hour
                    TypeEngine = "Electrical",
                    Power = 30,
                    Fuel = 10, // L/100 km
                    Description = "Quad bike is designed for active driving, including off-road driving, pits and boulders",
                    Price = 100,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes
                });
                bikes.Add(new Bike()
                {
                    Name = "Stels ATV 850G Guepard",
                    MaxSpeed = 90,
                    TypeEngine = "Physical 4",
                    Power = 40,
                    Fuel = 20,
                    Description = "The best choice for hunters and anglers.",
                    Price = 220,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes2
                });
                bikes.Add(new Bike()
                {
                    Name = "Avantis ATV Classic mini",
                    MaxSpeed = 55,
                    TypeEngine = "Electrical",
                    Power = 34,
                    Fuel = 25,
                    Description = "ATV for kids",
                    Price = 142,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes3
                });
                //=================================
                bikes.Add(new Bike()
                {
                    Name = "Suzuki MT-560",
                    MaxSpeed = 20,
                    TypeEngine = "single",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV for off-road trips",
                    Price = 100,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes4
                });
                bikes.Add(new Bike()
                {
                    Name = "Avantis Hunter 200 Premium",
                    MaxSpeed = 20,
                    TypeEngine = "Physical 2",
                    Power = 120,
                    Fuel = 30,
                    Description = "The best choice for hunters and anglers.",
                    Price = 100,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes5
                });
                bikes.Add(new Bike()
                {
                    Name = "Avantis Patriot Lux M",
                    MaxSpeed = 160,
                    TypeEngine = "Physical 2",
                    Power = 40,
                    Fuel = 30,
                    Description = "Quad bike is designed for active driving, including off-road driving, pits and boulders",
                    Price = 156,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes6
                });
                //===================
                bikes.Add(new Bike()
                {
                    Name = "Stels ATV 300B",
                    MaxSpeed = 120, //km/hour
                    TypeEngine = "Electrical",
                    Power = 30,
                    Fuel = 10, // L/100 km
                    Description = "Quad bike is designed for active driving, including off-road driving, pits and boulders",
                    Price = 100,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes7
                });
                bikes.Add(new Bike()
                {
                    Name = "Stels ATV 850G Guepard",
                    MaxSpeed = 90,
                    TypeEngine = "Physical 4",
                    Power = 40,
                    Fuel = 20,
                    Description = "The best choice for hunters and anglers.",
                    Price = 220,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes7
                });
                bikes.Add(new Bike()
                {
                    Name = "Avantis ATV Classic mini",
                    MaxSpeed = 55,
                    TypeEngine = "Electrical",
                    Power = 34,
                    Fuel = 25,
                    Description = "ATV for kids",
                    Price = 142,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes8
                });
                //=================
                bikes.Add(new Bike()
                {
                    Name = "Avantis Hunter 200 Premium",
                    MaxSpeed = 20,
                    TypeEngine = "Physical 2",
                    Power = 120,
                    Fuel = 30,
                    Description = "The best choice for hunters and anglers.",
                    Price = 100,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes9
                });
                bikes.Add(new Bike()
                {
                    Name = "Stels ATV 300B",
                    MaxSpeed = 120, //km/hour
                    TypeEngine = "Electrical",
                    Power = 30,
                    Fuel = 10, // L/100 km
                    Description = "Quad bike is designed for active driving, including off-road driving, pits and boulders",
                    Price = 100,
                    AccountId = us2.Id,
                    BikeImg = PhotoBytes4
                });
                bikes.Add(new Bike()
                {
                    Name = "Suzuki MT-560",
                    MaxSpeed = 20,
                    TypeEngine = "single",
                    Power = 120,
                    Fuel = 30,
                    Description = "ATV for off-road trips",
                    Price = 100,
                    AccountId = us.Id,
                    BikeImg = PhotoBytes7
                });

                context.AddRange(bikes);
                context.SaveChanges();
            }

            if (!context.Trips.Any())
            {
                List<Trip> trips = new List<Trip>();
                var us = _userManager.FindByNameAsync(providerEmail).Result;
                var us2 = _userManager.FindByNameAsync(providerEmailTwo).Result;

                #region upload photos
                string picturePath = "wwwroot/images_default/t1.jpg";
                FileStream fileStream = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes = new byte[fileStream.Length];
                fileStream.Read(PhotoBytes, 0, PhotoBytes.Length);
                fileStream.Close();

                string picturePath2 = "wwwroot/images_default/t2.jpg";
                FileStream fileStream2 = new FileStream(picturePath2, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes2 = new byte[fileStream2.Length];
                fileStream2.Read(PhotoBytes2, 0, PhotoBytes2.Length);
                fileStream2.Close();

                string picturePath3 = "wwwroot/images_default/t3.jpg";
                FileStream fileStream3 = new FileStream(picturePath3, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes3 = new byte[fileStream3.Length];
                fileStream3.Read(PhotoBytes3, 0, PhotoBytes3.Length);
                fileStream3.Close();

                string picturePath4 = "wwwroot/images_default/t4.jpg";
                FileStream fileStream4 = new FileStream(picturePath4, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes4 = new byte[fileStream4.Length];
                fileStream4.Read(PhotoBytes4, 0, PhotoBytes4.Length);
                fileStream4.Close();

                string picturePath5 = "wwwroot/images_default/t5.jpg";
                FileStream fileStream5 = new FileStream(picturePath5, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes5 = new byte[fileStream5.Length];
                fileStream5.Read(PhotoBytes5, 0, PhotoBytes5.Length);
                fileStream5.Close();

                string picturePath6 = "wwwroot/images_default/t6.jpg";
                FileStream fileStream6 = new FileStream(picturePath6, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes6 = new byte[fileStream6.Length];
                fileStream6.Read(PhotoBytes6, 0, PhotoBytes6.Length);
                fileStream6.Close();

                string picturePath7 = "wwwroot/images_default/t7.jpg";
                FileStream fileStream7 = new FileStream(picturePath7, FileMode.Open, FileAccess.Read);
                byte[] PhotoBytes7 = new byte[fileStream7.Length];
                fileStream7.Read(PhotoBytes7, 0, PhotoBytes7.Length);
                fileStream7.Close();
                #endregion

                trips.Add(new Trip()
                {
                    TripName = "Forest/Moutain adventure",
                    Type = "Forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "You will experience extreme driving skills, overcoming areas of complete off-road",
                    Price = 202,
                    TripImg = PhotoBytes,
                    AccountId = us.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Off-road skill",
                    Type = "Off-road",
                    Distance = 20,
                    AmountOfPeople = 8,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "Driving powerful quad bikes, you will drive through the most picturesque places.",
                    Price = 534,
                    TripImg = PhotoBytes2,
                    AccountId = us2.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Mysterious island",
                    Type = "Island road",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "You will drive a quad bike on forest roads and off-road sections. Get to Watchela, an abandoned village on a tiny island.",
                    Price = 210,
                    TripImg = PhotoBytes3,
                    AccountId = us.Id
                });

                //=========================================
                trips.Add(new Trip()
                {
                    TripName = "Mountain",
                    Type = "Off-road",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "Explore mountains and endless forests, impassable swamps, mysterious natural anomalies and mysterious natives of Mansi on quad bikes only by real adventurers.",
                    Price = 323,
                    TripImg = PhotoBytes4,
                    AccountId = us.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Narnia",
                    Type = "Forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "Driving powerful quad bikes, you will drive through the most picturesque places.",
                    Price = 450,
                    TripImg = PhotoBytes5,
                    AccountId = us.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Nobody read this text",
                    Type = "Mountain",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "You will drive a quad bike on forest roads and off-road sections",
                    Price = 1220,
                    TripImg = PhotoBytes6,
                    AccountId = us2.Id
                });
                //===================================
                trips.Add(new Trip()
                {
                    TripName = "Forest/Moutain adventure",
                    Type = "Forest",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "You will experience extreme driving skills, overcoming areas of complete off-road",
                    Price = 202,
                    TripImg = PhotoBytes7,
                    AccountId = us2.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Off-road skill",
                    Type = "Off-road",
                    Distance = 20,
                    AmountOfPeople = 8,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "Driving powerful quad bikes, you will drive through the most picturesque places.",
                    Price = 534,
                    TripImg = PhotoBytes3,
                    AccountId = us.Id
                });
                trips.Add(new Trip()
                {
                    TripName = "Mysterious island",
                    Type = "Island road",
                    Distance = 20,
                    AmountOfPeople = 20,
                    StartDate = DateTime.Now,
                    EndTrip = DateTime.Now,
                    Description = "You will drive a quad bike on forest roads and off-road sections. Get to Watchela, an abandoned village on a tiny island.",
                    Price = 210,
                    TripImg = PhotoBytes5,
                    AccountId = us2.Id
                });

                context.AddRange(trips);
                context.SaveChanges();
            }
        }
    }
}