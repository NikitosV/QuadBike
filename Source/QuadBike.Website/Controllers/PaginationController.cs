using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.BikeViewModels;

namespace QuadBike.Website.Controllers
{
    public class PaginationController : Controller
    {
        private IBikeService _bikeService;
        private ITripService _tripService;
        private IUserManagerService _userManagerService;

        public PaginationController(IBikeService bikeService, ITripService tripService, IUserManagerService userManagerService)
        {
            _bikeService = bikeService;
            _tripService = tripService;
            _userManagerService = userManagerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllBikes()
        {
            //List<Bike> ObjEmp = new List<Bike>()
            //{
            //    new Bike()
            //    {
            //        Id = 1, Name = "TEST", MaxSpeed = 100, TypeEngine = "test", Power = 100, Fuel = 200, Description = "121", Price = 100
            //    }
            //};

            var source = _bikeService.GetAllBikes();
            //JsonResult categoryJson = new JsonResult(source);
            return Json(source);
        }

        [HttpGet]
        public JsonResult GetBikesPaggination(int pageSize, int currentPage)
        {
            IQueryable<PaginationBikeViewModel> bikes = _bikeService.PaginationBikes(pageSize, currentPage);

            int totalCount = _bikeService.CountBikes();

            return Json(new { bikes, totalCount });
        }
    }
}