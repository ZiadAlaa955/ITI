using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    internal class Point3D(int x, int y, int z) : IComparable, ICloneable 
    {
        #region Automatic properties
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int Z { get; set; } = z;
        #endregion

        #region Chaining conatructors
        public Point3D() : this(0, 0, 0) { } //Constructor chaining, default constructor
        public Point3D(int _x, int _y) : this(_x, _y, 0) { } //Constructor chaining, 2 parameters
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
        #endregion overloading

        #region String overloading
        public static explicit operator string (Point3D p)
        {
            return p.ToString();
        }
        #endregion

        #region == override
        public static bool operator == (Point3D Left, Point3D Right)
        {
            return Left.X == Right.X && Left.Y == Right.Y && Left.Z == Right.Z;
        }
        public static bool operator !=(Point3D Left, Point3D Right)
        {
            return Left.X == Right.X || Left.Y == Right.Y || Left.Z == Right.Z;
        }
        #endregion
        public override bool Equals(object obj)
        {
            if (obj is Point3D p) return this == p;
            return false;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            if (obj is Point3D otherPoint)
            {
                if (this.X != otherPoint.X)
                {
                    return this.X.CompareTo(otherPoint.X);
                }

                return this.Y.CompareTo(otherPoint.Y);
            }
            return 1;
        }
        #endregion

        #region ICloneable 
        public object Clone()
        {
            return new Point3D(this.X, this.Y, this.Z);
        }
        #endregion

    }
}
