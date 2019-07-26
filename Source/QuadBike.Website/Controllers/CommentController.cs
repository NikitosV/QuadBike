using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context.CommitProvider;
using QuadBike.Model.ViewModel.CommentViewModels;

namespace QuadBike.Website.Controllers
{
    public class CommentController : Controller
    {
        public readonly IUserManagerService _userManagerService;
        public readonly ICommentService _commentService;
        private readonly ICommitProvider _commitProvider;

        public CommentController(IUserManagerService userManagerService, ICommentService commentService, ICommitProvider commitProvider)
        {
            _commitProvider = commitProvider;
            _userManagerService = userManagerService;
            _commentService = commentService;
        }

        #region TEST
        [HttpGet]
        public IActionResult Test(string providerId)
        {
            var res = _commentService.GetAllCommentsOfProvider(providerId);
            ViewBag.ProviderId = providerId;
            return View(res);
        }

        [HttpPost]
        public IActionResult Create(CommentViewModel commnent)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            if (!ModelState.IsValid)
            {
                var message = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                return BadRequest(message);
            }
            else
            {
                _commentService.Create(commnent.Content, userId.Result.Id, commnent.AccountId, userId.Result.Email);
                var res = new List<CommentViewModel>();
                res.Add(new CommentViewModel { Content = commnent.Content, AccountId = commnent.AccountId, UserId = userId.Result.Id, UserName = userId.Result.Email, Time = DateTime.Now });
                return PartialView("TestComments", res);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int? CommentId, string AccountId)
        {
            if (CommentId != null)
            {
                _commentService.DeleteById(CommentId);
                _commitProvider.Save();
                var res = _commentService.GetAllCommentsOfProvider(AccountId);
                return PartialView("TestComments", res);
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}