using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment2.Entities
{
    [Table("frontend")]
    public class FrontEndEntity
    {
        [Key]
        [Column("user_name")]
        [StringLength(50)]
        public required string UserName { get; set; }

        [Required]
        [Column("pass_word")]
        [StringLength(50)]
        public required string Password { get; set; }
    }
}
