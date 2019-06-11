using System;
using System.Collections.Generic;
using System.Text;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context.CommitProvider;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.CommentViewModels;

namespace QuadBike.Logic.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommitProvider _commitProvider;
        private readonly IUserManagerService _userManagerService;

        public CommentService(ICommentRepository commentRepository, ICommitProvider commitProvider, IUserManagerService userManagerService)
        {
            _commentRepository = commentRepository;
            _commitProvider = commitProvider;
            _userManagerService = userManagerService;
        }

        public void Create(CommentViewModel model, string userId, string providerId, string currentUserName)
        {
            //var res = _userManagerService.GetUserById(userId);
            _commentRepository.Create(new Comment
            {
                Content = model.Content,
                OrderPlaced = DateTime.Now,
                AccountId = providerId,
                Name = currentUserName,
                UserId = userId
            });
            _commitProvider.Save();
        }

        public IEnumerable<CommentViewModel> GetAllCommentsOfProvider(string id)
        {
            var res = _commentRepository.GetAllCommentsOfProvider(id);
            return res;
        }
    }
}
