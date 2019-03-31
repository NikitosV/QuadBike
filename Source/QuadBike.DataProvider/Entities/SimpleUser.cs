using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("SimpleUser")]
    public class SimpleUser
    {
        [Key]
        public int Id { get; set; }                //ID

        [MaxLength(50)]
        public string Name { get; set; }           //Name

        [MaxLength(50)]
        public string Surname { get; set; }        //Surname

        public virtual ICollection<RentBike> RentBikes { get; set; }

        public virtual ICollection<RentTrip> RentTrips { get; set; }
    }
}