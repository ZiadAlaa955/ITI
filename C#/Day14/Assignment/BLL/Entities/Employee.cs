using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Employee : EntityBase
    {
        public Employee() => this.State = EntitySate.Added;

        public required string EmpId { get; set; }

        public required string Fname
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added)
                        this.State = EntitySate.Modified;
                }
            }
        }

        public string? Minit
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added)
                        this.State = EntitySate.Modified;
                }
            }
        }

        public required string Lname
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added)
                        this.State = EntitySate.Modified;
                }
            }
        }

        public required short JobId
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added)
                        this.State = EntitySate.Modified;
                }
            }
        }

        public byte? JobLvl
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added)
                        this.State = EntitySate.Modified;
                }
            }
        }

        public required string PubId
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added)
                        this.State = EntitySate.Modified;
                }
            }
        }

        public DateTime HireDate
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added)
                        this.State = EntitySate.Modified;
                }
            }
        }
    }
}
