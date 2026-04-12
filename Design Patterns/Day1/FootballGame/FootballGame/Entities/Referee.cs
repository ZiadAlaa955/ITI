using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame.Entities
{
    public class Referee
    {
        public string Name { get; set; }
        Position BallPosition { get; set; }

        public Referee(string name, Ball ball)
        {
            Name = name;
            ball.BallPositionChanged += HandleBallPositionChanged;
        }

        void HandleBallPositionChanged(object sender, BallPositionEventArgs e)
        {
            BallPosition = e.NewPosition;
            Console.WriteLine($"Referee: {Name} Watches the ball closely at postion: {BallPosition}");
        }
    }
}
