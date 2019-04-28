using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context.CommitProvider;
using QuadBike.Model.ViewModel.Pagination;
using QuadBike.Model.ViewModel.TripViewModels;

namespace QuadBike.Website.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IUserManagerService _userManagerService;
        private readonly ICommitProvider _commitProvider;

        public TripController(ITripService tripService, IUserManagerService userManagerService, ICommitProvider commitProvider)
        {
            _tripService = tripService;
            _userManagerService = userManagerService;
            _commitProvider = commitProvider;
        }

        public IActionResult Index(int page = 1)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            int pageSize = 10;   // количество элементов на странице

            var source = _tripService.GetTripsOfCurrentProvider(userId.Result.Id);
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            TripViewModel viewModel = new TripViewModel
            {
                PageViewModel = pageViewModel,
                Trips = items
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TripViewModel trip)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            if (ModelState.IsValid)
            {
                if (trip.TripImg != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(trip.TripImg.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)trip.TripImg.Length);
                    }
                    _tripService.CreateTrip(trip, userId.Result.Id, imageData);
                    return RedirectToAction("Index");
                }
            }
            return View(trip);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _tripService.DeleteById(id);
                _commitProvider.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}