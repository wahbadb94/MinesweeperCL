using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;

            Point that = obj as Point;

            return (this.X == that.X && this.Y == that.Y);
        }

        public override int GetHashCode()
        {
            return X * 31 + Y;
        }
    }
}
