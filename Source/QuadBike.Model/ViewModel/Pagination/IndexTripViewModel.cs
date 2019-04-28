using Microsoft.AspNetCore.Http;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.Pagination
{
    public class IndexTripViewModel
    {
        public IEnumerable<Trip> Trips { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
