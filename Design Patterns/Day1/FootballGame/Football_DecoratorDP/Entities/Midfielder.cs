using System;
using System.Collections.Generic;
using System.Text;

namespace Football_DecoratorDP.Entities
{
    public class Midfielder : PlayerRole
    {
        public void Dribble()
        {
            Console.WriteLine($"{Name}, The midfielder is dribbiling");
        }
    }
}
