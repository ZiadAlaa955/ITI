using System;
using System.Collections.Generic;
using System.Text;

namespace Football_StrategyDP.Entites
{
    public class DefendStrategy : TeamStrategy
    {
        public override void play()
        {
            Console.WriteLine("Defending");
        }
    }
}
