using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Website.Models;

namespace QuadBike.Website.Controllers
{
    public class HomeController : Controller
    {
        private IBikeService _bikeService;

        public HomeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public void Index()
        {

            Response.WriteAsync(_bikeService.test());
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
