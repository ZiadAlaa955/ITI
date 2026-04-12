using System;
using System.Collections.Generic;
using System.Text;

namespace Football_StrategyDP.Entites
{
    public class AttackStrategy : TeamStrategy
    {
        public override void play()
        {
            Console.WriteLine("Attacking");
        }
    }
}
