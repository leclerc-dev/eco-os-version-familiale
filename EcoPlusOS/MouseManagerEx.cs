using Cosmos.System.Graphics;
using CMouse = Cosmos.System.MouseManager;
using NetPoint = System.Drawing.Point;
namespace EcoPlusOS
{
    public static class MouseManagerEx
    {
        public static Point ToPoint() => new Point((int)CMouse.X, (int)CMouse.Y);
        public static NetPoint ToSystemPoint() => new NetPoint((int)CMouse.X, (int)CMouse.Y);
        public static void SetDimensions(Mode mode)
        {
            CMouse.ScreenHeight = (uint)mode.Rows;
            CMouse.ScreenWidth = (uint)mode.Columns;
        }
    }
}