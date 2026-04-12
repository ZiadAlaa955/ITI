using System;
using System.Collections.Generic;
using System.Text;

namespace Football_DecoratorDP.Entities
{
    public class Defender : PlayerRole
    {
        public void Defend()
        {
            Console.WriteLine($"{Name}, The Defender is defending");
        }
    }
}
