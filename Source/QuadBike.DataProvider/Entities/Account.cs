using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }                   //ID

        [MaxLength(50)]
        public string Email { get; set; }             //Email

        [MaxLength(50)]
        public string Password { get; set; }         //Password

        public bool IsActivate { get; set; }          // Activate account of user

        public bool IsVerified { get; set; }         // is account verified

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
