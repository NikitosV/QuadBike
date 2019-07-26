using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.CommentViewModels;

namespace QuadBike.DataProvider.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private IQuadBikeContext _db;

        public CommentRepository(IQuadBikeContext context)
        {
            this._db = context;
        }

        public void Create(Comment item)
        {
            _db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment item = _db.Comments.Find(id);
            if (item != null)
                _db.Comments.Remove(item);
        }

        public Comment Get(int id)
        {
            return _db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _db.Comments;
        }

        public void Update(Comment item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<CommentViewModel> GetAllCommentsOfProvider(string id)
        {
            var res = (from comment in _db.Comments
                join provider in _db.Accounts on comment.AccountId equals provider.Id
                select new CommentViewModel()
                {
                    CommentId = comment.CommentId,
                    Content = comment.Content,
                    AccountId = provider.Id,
                    UserId = comment.UserId,
                    UserName = comment.Name,
                    Time = comment.OrderPlaced
                }).ToList();
            return res;

            //var res = _db.Comments.Where(x => x.AccountId.Equals(id));
            //return res;
        }

        public void DeleteById(int? id)
        {
            Comment item = _db.Comments.Find(id);
            if (item != null)
                _db.Comments.Remove(item);
        }
    }
}
