using Cosmos.System.Graphics;

namespace EcoPlusOS
{
    public static class UsefulExtensions 
    {
        public static bool AreTheSame(this in Point p1, in Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static unsafe bool AreTheSame(this Point p1, Point* p2)
        {
            return p1.X == p2->Y && p1.Y == p2->Y;
        }
    }
}