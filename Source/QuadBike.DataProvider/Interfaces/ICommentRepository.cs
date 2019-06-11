using System;
using System.Collections.Generic;
using System.Text;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.CommentViewModels;

namespace QuadBike.DataProvider.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<CommentViewModel> GetAllCommentsOfProvider(string id);
    }
}
