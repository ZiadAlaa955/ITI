using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame.Entities
{
    public abstract class Ball
    {
        public event EventHandler<BallPositionEventArgs> BallPositionChanged;
        public void NotifyBallPosition(Position newPosition)
        {
            BallPositionChanged?.Invoke(this, new BallPositionEventArgs(newPosition));
        }
    }
}
