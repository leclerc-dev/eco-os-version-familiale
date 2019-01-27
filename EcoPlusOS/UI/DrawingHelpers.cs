using System.Drawing;
using Cosmos.System.Graphics;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI
{
    public static class DrawingHelpers
    {
        public static void DrawRectanglePartial(UIEnvironment env, Pen pen, Rectangle bounds, Rectangle relativeBounds)
        {
            var cosPoint = new Point(bounds.X, bounds.Y);
            Kernel.PrintDebug("drawing @ " + bounds.X + " | " + bounds.Y);
            env.DrawFilledRectangle(pen, cosPoint, relativeBounds.Width, relativeBounds.Height);
        }
    }
}