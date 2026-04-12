using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame.Entities
{
    public class Football : Ball
    {

        Position myPosition { get; set; }

        public Football()
        {
            myPosition = new Position(0, 0, 0);
        }

        public Position GetBallPosition() => myPosition;

        public void SetBallPosition(Position p)
        {
            myPosition.X = p.X;
            myPosition.Y = p.Y;
            myPosition.Z = p.Z;
            NotifyBallPosition(myPosition);
        }
    }
}
