using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.ViewModel.CommentViewModels;

namespace QuadBike.Website.Controllers
{
    public class CommentController : Controller
    {
        public readonly IUserManagerService _userManagerService;
        public readonly ICommentService _commentService;

        public CommentController(IUserManagerService userManagerService, ICommentService commentService)
        {
            _userManagerService = userManagerService;
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult Index(string providerId)
        {
            TempData["PROVID"] = providerId;
            var res = _commentService.GetAllCommentsOfProvider(providerId);
            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CommentViewModel commnent)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);
            var providerId = Convert.ToString(TempData["PROVID"]);

            if (ModelState.IsValid)
            {
                _commentService.Create(commnent, userId.Result.Id, providerId, userId.Result.Email);
                return RedirectToAction("Index");
            }
            return View(commnent);
        }
    }
}