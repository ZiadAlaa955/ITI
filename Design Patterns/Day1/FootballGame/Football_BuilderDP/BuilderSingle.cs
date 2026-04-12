using Football_BuilderDP.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_BuilderDP
{
    public class BuilderSingle : IBuilder
    {
        private PlayGround product = new PlayGround();

        public void BuildSurface()
        {
            product.Add("Premium Natural Grass Pitch");
        }

        public void BuildGallery()
        {
            product.Add("Classic Single-Tier Gallery");
        }

        public void BuildAudiance()
        {
            product.Add("15,000 Capacity Local Seating");
        }

        public PlayGround GetGround()
        {
            return product;
        }
    }
}
