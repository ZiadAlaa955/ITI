using System;
using System.Collections.Generic;
using System.Text;

namespace Football_DecoratorDP.Entities
{
    public abstract class Player
    {
        public string Name { get; set; }

        public abstract void PassBall();
    }
}
