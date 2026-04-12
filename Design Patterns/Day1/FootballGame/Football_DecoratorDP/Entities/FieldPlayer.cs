using System;
using System.Collections.Generic;
using System.Text;

namespace Football_DecoratorDP.Entities
{
    public class FieldPlayer : Player
    {
        public FieldPlayer(string name)
        {
            Name = name;
        }

        public override void PassBall()
        {
            Console.WriteLine($"{Name}, The Field player is passing the ball");
        }
    }
}
