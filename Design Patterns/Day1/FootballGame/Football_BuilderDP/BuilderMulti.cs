using Football_BuilderDP.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_BuilderDP
{
    public class BuilderMulti : IBuilder
    {
        private PlayGround product = new PlayGround();

        public void BuildSurface()
        {
            product.Add("Artificial Multi-Purpose Turf");
        }

        public void BuildGallery()
        {
            product.Add("Massive 3-Tier VIP Gallery");
        }

        public void BuildAudiance()
        {
            product.Add("80,000 Capacity Seating");
        }

        public PlayGround GetGround()
        {
            return product;
        }
    }
}
