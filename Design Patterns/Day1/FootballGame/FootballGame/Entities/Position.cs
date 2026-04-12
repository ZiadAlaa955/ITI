using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame.Entities
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position(int _X, int _Y, int _Z)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
        }

        public override string ToString() => $"x:{X}, y:{Y}, z:{Z}";
    }
}
