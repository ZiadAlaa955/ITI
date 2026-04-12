using FootballGame.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame
{
    public class BallPositionEventArgs : EventArgs
    {
        public Position NewPosition { get; set; }

        public BallPositionEventArgs(Position position)
        {
            NewPosition = position;
        }
    }
}
