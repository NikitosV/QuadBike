using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuadBike.Model.ViewModel.CommentViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Field not be empty!")]
        [StringLength(5, ErrorMessage = "String should not be more than 5 symbols!")]
        //[RegularExpression(@"[<>@_]+", ErrorMessage = "Forbidden symbol!")]
        public string Content { get; set; }     //message

        public string UserId { get; set; }

        public string AccountId { get; set; }

        public string UserName { get; set; }

        public DateTime Time { get; set; }
    }
}
