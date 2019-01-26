using System.Drawing;
using EcoPlusOS.UI.Core;
using EcoPlusOS.UI.Elements;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI
{
    public static class DrawingExtensions
    {
        public static void Draw(this Drawing drawing, UIEnvironment e, Point loc, int width = 0, int height = 0)
        {
            drawing.Draw(e, loc, new Size(width, height));
        }
    }
}