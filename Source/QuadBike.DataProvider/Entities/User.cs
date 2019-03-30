using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }                //ID

        [MaxLength(50)]
        public string Name { get; set; }           //Name

        [MaxLength(50)]
        public string Surname { get; set; }        //Surname

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }    //Birthday

        [StringLength(13)]
        public string Mobile { get; set; }        //Mobile

        public byte[] Photo { get; set; }          //Photo

        [ForeignKey("Acc")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public virtual ICollection<RentBike> RentBikes { get; set; }

        public virtual ICollection<RentTrip> RentTrips { get; set; }
    }
}
