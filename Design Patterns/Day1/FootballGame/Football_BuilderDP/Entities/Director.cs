using System;
using System.Collections.Generic;
using System.Text;

namespace Football_BuilderDP.Entities
{
    public class Director
    {
        public void ConstructGround(IBuilder builder)
        {
            builder.BuildSurface();
            builder.BuildGallery();
            builder.BuildAudiance();
        }
    }
}
