using System;
using System.Collections.Generic;
using System.Text;

namespace Football_DecoratorDP.Entities
{
    public class GoalKeeper : Player
    {
        public GoalKeeper(string name)
        {
            Name = name;
        }

        public override void PassBall()
        {
            Console.WriteLine($"{Name}, The GoalKeeper is passing the ball");
        }
    }
}
