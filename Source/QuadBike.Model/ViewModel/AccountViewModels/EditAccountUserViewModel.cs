using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuadBike.Model.ViewModel.AccountViewModels
{
    public class EditAccountUserViewModel
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string Description { get; set; }

        [Display(Name = "Account img")]
        public IFormFile AccountImg { get; set; }
    }
}
