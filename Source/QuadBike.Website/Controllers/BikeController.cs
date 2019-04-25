using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context.CommitProvider;
using QuadBike.Model.ViewModel.BikeViewModels;

namespace QuadBike.Website.Controllers
{
    [Authorize(Roles = "provider")]
    public class BikeController : Controller
    {
        private readonly IBikeService _bikeService;
        private readonly IUserManagerService _userManagerService;
        private readonly ICommitProvider _commitProvider;

        public BikeController(IBikeService bikeService, IUserManagerService userManagerService, ICommitProvider commitProvider)
        {
            _bikeService = bikeService;
            _userManagerService = userManagerService;
            _commitProvider = commitProvider;
        }

        public IActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            return View(_bikeService.GetBikesOfCurrentProvider(userId.Result.Id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _bikeService.DeleteById(id);
                _commitProvider.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(BikeViewModel bike)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            if (ModelState.IsValid)
            {
                _bikeService.CreateBike(bike, userId.Result.Id);
                return RedirectToAction("Index");
            }
            return View(bike);
        }
    }
}