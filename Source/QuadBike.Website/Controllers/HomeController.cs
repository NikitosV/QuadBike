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

            // var source = _bikeService.GetAllBikes();
            var source = _bikeService.GetBikesWithProviderInfo();
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

        public IActionResult IndexPartial(int page = 1)
        {
            int pageSize = 9;   // количество элементов на странице

            // var source = _bikeService.GetAllBikes();
            var source = _bikeService.GetBikesWithProviderInfo();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Bikes = items
            };
            return PartialView(viewModel);
        }

        public IActionResult IndexData(int page = 1)
        {
            int pageSize = 9;   // количество элементов на странице

            // var source = _bikeService.GetAllBikes();
            var source = _bikeService.GetBikesWithProviderInfo();
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

        public IActionResult ProviderList(int page = 1)
        {
            int pageSize = 8;

            var source = _userManagerService.AllProviderByRoleName("provider");
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProviderListViewModel viewModel = new ProviderListViewModel()
            {
                PageViewModel = pageViewModel,
                Accounts = items
            };
            return View(viewModel);
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

        [HttpGet]
        public IActionResult CheckEmailIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BikesOfCurrentProvider(string providerId)
        {
            var res = _bikeService.GetBikesOfCurrentProvider(providerId);
            return View(res);
        }

        [HttpGet]
        public IActionResult TripsOfCurrentProvider(string providerId)
        {
            var res = _tripService.GetTripsOfCurrentProvider(providerId);
            return View(res);
        }
    }
}
