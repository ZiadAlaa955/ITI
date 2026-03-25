using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class EntityBase
    {
        public EntitySate State { get; set; } = EntitySate.UnChanged;
    }
}
