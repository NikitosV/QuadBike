using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Common.Filters.TripFilter;
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

        public IActionResult Index(string name, int page = 1, SortState sortOrder = SortState.TripNameAsc)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            int pageSize = 10;   // количество элементов на странице

            var source = _tripService.GetTripsOfCurrentProvider(userId.Result.Id);

            if (!String.IsNullOrEmpty(name))
            {
                source = source.Where(p => p.TripName.Contains(name));
            }

            switch (sortOrder)
            {
                case SortState.TripNameDesc:
                    source = source.OrderByDescending(s => s.TripName);
                    break;
                case SortState.TypeAsc:
                    source = source.OrderBy(s => s.Type);
                    break;
                case SortState.TypeDesc:
                    source = source.OrderByDescending(s => s.Type);
                    break;
                case SortState.DistanceAsc:
                    source = source.OrderBy(s => s.Distance);
                    break;
                case SortState.DistanceDesc:
                    source = source.OrderByDescending(s => s.Distance);
                    break;
                case SortState.AmountOfPeopleAsc:
                    source = source.OrderBy(s => s.AmountOfPeople);
                    break;
                case SortState.AmountOfPeopleDesc:
                    source = source.OrderByDescending(s => s.AmountOfPeople);
                    break;
                case SortState.StartDateAsc:
                    source = source.OrderBy(s => s.StartDate);
                    break;
                case SortState.StartDateDesc:
                    source = source.OrderByDescending(s => s.StartDate);
                    break;
                case SortState.PriceAsc:
                    source = source.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    source = source.OrderByDescending(s => s.Price);
                    break;

                default:
                    source = source.OrderBy(s => s.TripName);
                    break;
            }

            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            TripViewModel viewModel = new TripViewModel
            {
                PageViewModel = pageViewModel,
                TripFilterViewModel = new TripFilterViewModel(name),
                TripSortViewModel = new TripSortViewModel(sortOrder),
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

        public IActionResult Edit(int id)
        {
            var res = _tripService.GetTripById(id);

            if (res == null)
            {
                return NotFound();
            }

            ChangeTripViewModel model = new ChangeTripViewModel
            {
                Id = res.Id,
                TripName = res.TripName,
                Type = res.Type,
                Distance = res.Distance,
                AmountOfPeople = res.AmountOfPeople,
                StartDate = res.StartDate,
                EndTrip = res.EndTrip,
                Description = res.Description,
                Price = res.Price
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ChangeTripViewModel model)
        {
            if (ModelState.IsValid)
            {
                var trip = _tripService.GetTripById(model.Id);

                if (trip != null)
                {
                    if (model.TripImg != null)
                    {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(model.TripImg.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)model.TripImg.Length);
                        }

                        trip.TripName = model.TripName;
                        trip.Type = model.Type;
                        trip.Distance = model.Distance;
                        trip.AmountOfPeople = model.AmountOfPeople;
                        trip.StartDate = model.StartDate;
                        trip.EndTrip = model.EndTrip;
                        trip.Description = model.Description;
                        trip.TripImg = imageData;

                        var result = _tripService.Update(trip);
                        if (result == true)
                        {
                            _commitProvider.Save();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            return View(model);
        }
    }
}