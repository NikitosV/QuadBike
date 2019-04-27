using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.Pagination
{
    public class AccountViewModel
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
