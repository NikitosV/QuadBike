using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuadBike.Model.ViewModel.TripViewModels
{
    public class TripViewModel
    {
        [Required]
        [Display(Name = "Trip Name")]
        public string TripName { get; set; }

        [Required]
        [Display(Name = "Type of trip")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Distance")]
        public int Distance { get; set; }

        [Required]
        [Display(Name = "Amount of people")]
        public int AmountOfPeople { get; set; }

        [Required]
        [Display(Name = "Date of Start")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Date of End")]
        public DateTime EndTrip { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

        //[Required]
        //[Display(Name = "Is Activate?")]
        //public bool IsActivate { get; set; }
    }
}