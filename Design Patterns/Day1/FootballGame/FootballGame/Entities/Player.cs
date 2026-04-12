using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame.Entities
{
    public class Player
    {
        public string Name { get; set; }
        Position BallPosition { get; set; }

        public Player(string name, Ball ball)
        {
            Name = name;
            ball.BallPositionChanged += HandleBallPositionChanged;
        }

        void HandleBallPositionChanged(object sender, BallPositionEventArgs e)
        {
            BallPosition = e.NewPosition;
            Console.WriteLine($"Player: {Name} changed ball postion to {BallPosition}");
        }
    }
}
