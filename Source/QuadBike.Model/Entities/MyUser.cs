using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    [Table("MyUser")]
    public class MyUser
    {
        [Key]
        public int Id { get; set; }                //ID

        [MaxLength(50)]
        public string Name { get; set; }           //Name

        [MaxLength(50)]
        public string Surname { get; set; }        //Surname

        public virtual ICollection<RentBike> RentBikes { get; set; }

        public virtual ICollection<RentTrip> RentTrips { get; set; }

        public Account Account { get; set; }
    }
}
