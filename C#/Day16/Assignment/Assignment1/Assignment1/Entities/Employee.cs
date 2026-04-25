using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment1.Entities
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("emp_id")]
        [StringLength(9)]
        public string EmpId { get; set; }

        [Required]
        [Column("fname")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Column("minit")]
        [StringLength(1)]
        public string MiddleInitial { get; set; }

        [Required]
        [Column("lname")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Column("job_id")]
        public short JobId { get; set; }

        [Column("job_lvl")]
        public byte? JobLevel { get; set; }

        [Required]
        [Column("pub_id")]
        [StringLength(4)]
        public string PubId { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }


        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }
}
