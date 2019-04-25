﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuadBike.Model.ViewModel.BikeViewModels
{
    public class BikeViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Max Speed")]
        public int MaxSpeed { get; set; }

        [Required]
        [Display(Name = "Type of Engine")]
        public string TypeEngine { get; set; }

        [Required]
        [Display(Name = "Power")]
        public int Power { get; set; }

        [Required]
        [Display(Name = "Fuel")]
        public int Fuel { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}