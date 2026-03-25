using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Job : EntityBase
    {
        public Job() => this.State = EntitySate.Added;

        public required short JobId { get; set; }

        public required string JobDesc
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added) this.State = EntitySate.Modified;
                }
            }
        }

        public byte MinLvl
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added) this.State = EntitySate.Modified;
                }
            }
        }

        public byte MaxLvl
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    if (State != EntitySate.Added) this.State = EntitySate.Modified;
                }
            }
        }
    }
}