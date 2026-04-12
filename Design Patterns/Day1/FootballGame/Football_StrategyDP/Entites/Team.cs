using System;
using System.Collections.Generic;
using System.Text;

namespace Football_StrategyDP.Entites
{
    public class Team
    {
        public string Name { get; set; }
        TeamStrategy Strategy;

        public Team(string name , TeamStrategy strategy)
        {
            Name = name;
            Strategy = strategy;
        }

        public void SetStrategy(TeamStrategy s)
        {
            Strategy = s;
            Console.WriteLine($"Strategy Now is: {Strategy}");
        }

        public void PlayGame()
        {
            Console.Write($"{Name} Now is ");
            Strategy.play();
        }
    }
}
