using System.Drawing;
using System.Runtime.CompilerServices;
using Cosmos.System.Graphics;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Elements
{
    public class EcoPlusLogo : IDrawing
    {
        private static readonly Pen EcoPlusBackgroundPen = new Pen(Color.Blue);
        public void Draw(UIEnvironment canvas, Point location, int width, int height)
        {
            canvas.DrawFilledRectangle(EcoPlusBackgroundPen, location, width, height);
        }
    }
}