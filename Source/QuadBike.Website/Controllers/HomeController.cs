using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.ViewModel.Pagination;
using QuadBike.Website.Models;

namespace QuadBike.Website.Controllers
{
    public class HomeController : Controller
    {
        private IBikeService _bikeService;
        private ITripService _tripService;
        private IUserManagerService _userManagerService;

        public HomeController(IBikeService bikeService, ITripService tripService, IUserManagerService userManagerService)
        {
            _bikeService = bikeService;
            _tripService = tripService;
            _userManagerService = userManagerService;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 9;   // количество элементов на странице

            var source = _bikeService.GetAllBikes();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Bikes = items
            };
            return View(viewModel);
        }

        public IActionResult ListTrips(int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            var source = _tripService.GetAllTrips();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexTripViewModel viewModel = new IndexTripViewModel
            {
                PageViewModel = pageViewModel,
                Trips = items
            };
            return View(viewModel);
        }

        public IActionResult ProviderList()
        {
            var res = _userManagerService.AllProviderByRoleName("provider");
            return View(res);
        }

        public IActionResult ProviderBike(string accId)
        {
            var res = _userManagerService.GetProviderOfBike(accId);
            return View(res);
        }

        public IActionResult ProviderTrip(string tripId)
        {
            var res = _userManagerService.GetProviderOfTrip(tripId);
            return View(res);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
