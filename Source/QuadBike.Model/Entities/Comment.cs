using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }           //Id

        [MaxLength(100)]
        public string Content { get; set; }     //message

        public DateTime OrderPlaced { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}