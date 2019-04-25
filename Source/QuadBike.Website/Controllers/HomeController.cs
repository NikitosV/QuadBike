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

        public HomeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
