using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment1.Entities
{
    [Table("jobs")]
    public class Job
    {
        [Key]
        [Column("job_id")]
        public short JobId { get; set; }

        [Required]
        [Column("job_desc")]
        [StringLength(50)]
        public string JobDesc { get; set; }

        [Column("min_lvl")]
        public byte MinLvl { get; set; }

        [Column("max_lvl")]
        public byte MaxLvl { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public override string ToString()
        {
            return JobDesc;
        }
    }
}
