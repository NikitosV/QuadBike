﻿using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using QuadBike.Model.ViewModel.BikeViewModels;

namespace QuadBike.Model.ViewModel.Pagination
{
    public class IndexViewModel
    {
        //public IEnumerable<Bike> Bikes { get; set; }
        public IEnumerable<IndexBikeViewModel> Bikes { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
