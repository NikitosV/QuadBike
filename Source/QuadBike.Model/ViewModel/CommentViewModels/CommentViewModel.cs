using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.CommentViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }     //message

        public string UserId { get; set; }

        public string AccountId { get; set; }

        public string UserName { get; set; }

        public DateTime Time { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
