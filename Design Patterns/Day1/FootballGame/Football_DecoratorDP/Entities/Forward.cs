using System;
using System.Collections.Generic;
using System.Text;

namespace Football_DecoratorDP.Entities
{
    public class Forward : PlayerRole
    {
        public void ShootGoal()
        {
            Console.WriteLine($"{Name}, The attcker is Shooting");
        }
    }
}
