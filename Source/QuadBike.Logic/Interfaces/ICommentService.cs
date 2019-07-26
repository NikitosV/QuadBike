using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using QuadBike.Model.ViewModel.CommentViewModels;

namespace QuadBike.Logic.Interfaces
{
    public interface ICommentService
    {
        void Create(string model, string userId, string providerId, string currentUserName);
        IEnumerable<CommentViewModel> GetAllCommentsOfProvider(string id);
        void DeleteById(int? id);
    }
}