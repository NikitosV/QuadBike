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

        //[HttpGet]
        //public IActionResult Index(string providerId)
        //{
        //    var res = _commentService.GetAllCommentsOfProvider(providerId);
        //    return View(res);
        //}

        #region TEST
        [HttpGet]
        public IActionResult Test(string providerId)
        {
            var res = _commentService.GetAllCommentsOfProvider(providerId);
            ViewBag.ProviderId = providerId;
            return View(res);
        }

        //[HttpGet]
        //public IActionResult TestComments(string providerId)
        //{
        //    var res = _commentService.GetAllCommentsOfProvider(providerId);
        //    return PartialView(res);
        //}

        [HttpPost]
        public IActionResult Create(string Content, string AccountId)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            //if (!ModelState.IsValid)
            //{
            //    var message = string.Join(" | ", ModelState.Values
            //        .SelectMany(v => v.Errors)
            //        .Select(e => e.ErrorMessage));
            //    return BadRequest();
            //}
            //else
            //{
            //    _commentService.Create(Content, userId.Result.Id, AccountId, userId.Result.Email);
            //    var res = new List<CommentViewModel>();
            //    res.Add(new CommentViewModel { Content = Content, AccountId = AccountId, UserId = userId.Result.Id, UserName = userId.Result.Email, Time = DateTime.Now });
            //    return PartialView("TestComments", res);
            //}
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return BadRequest(message);
            }
            else
            {
                _commentService.Create(Content, userId.Result.Id, AccountId, userId.Result.Email);
                var res = new List<CommentViewModel>();
                res.Add(new CommentViewModel { Content = Content, AccountId = AccountId, UserId = userId.Result.Id, UserName = userId.Result.Email, Time = DateTime.Now });
                return PartialView("TestComments", res);
            }
        }
        #endregion

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(CommentViewModel commnent)
        //{
        //    var currentUserName = User.Identity.Name;
        //    var userId = _userManagerService.GetUserByName(currentUserName);
        //    var providerId = Convert.ToString(TempData["PROVID"]);

        //    if (ModelState.IsValid)
        //    {
        //        _commentService.Create(commnent, userId.Result.Id, providerId, userId.Result.Email);
        //        return RedirectToAction("Test");
        //    }
        //    return View(commnent);
        //}














        //[HttpPost]
        //public IActionResult Create(CommentViewModel commnent)
        //{
        //    var currentUserName = User.Identity.Name;
        //    var userId = _userManagerService.GetUserByName(currentUserName);
        //    var providerId = Convert.ToString(TempData["PROVID"]);

        //    if (ModelState.IsValid)
        //    {
        //        _commentService.Create(commnent, userId.Result.Id, providerId, userId.Result.Email);
        //        return RedirectToAction("Index");
        //    }
        //    return View(commnent);
        //}


    }
}