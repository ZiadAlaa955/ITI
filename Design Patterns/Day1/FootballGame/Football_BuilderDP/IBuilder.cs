using Football_BuilderDP.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_BuilderDP
{
    public interface IBuilder
    {
        public void BuildSurface();
        public void BuildGallery();
        public void BuildAudiance();

        PlayGround GetGround();
    }
}
