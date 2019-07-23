using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.CommentViewModels
{
    public class ProviderCommentViewModel
    {
        public string Email { get; set; }
        public IEnumerable<CommentViewModel> CommentViewModels { get; set; } //?????????????????
        public string ProviderId { get; set; }
    }
}
