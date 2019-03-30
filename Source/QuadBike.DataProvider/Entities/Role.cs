using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }              //ID

        [MaxLength(50)]
        public string NameOfRole { get; set; }   //Name of Role

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
