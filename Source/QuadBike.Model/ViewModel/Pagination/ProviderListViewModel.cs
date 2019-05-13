using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.Pagination
{
    public class ProviderListViewModel
    {
        public IEnumerable<Account> Accounts { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
