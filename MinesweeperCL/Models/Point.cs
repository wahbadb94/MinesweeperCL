namespace MinesweeperCL.Models
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

            var that = (Point) obj;

            return (X == that.X && Y == that.Y);
        }

        public override int GetHashCode()
        {
            return X * 31 + Y;
        }
    }
}
