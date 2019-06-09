using Microsoft.AspNetCore.Identity;
using QuadBike.Model.ViewModel.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    public class Account : IdentityUser
    {
        public byte[] AccountImg { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}